using DndCharacterSheetAPI.Application.Enums;
using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Domain.Context;
using DndCharacterSheetAPI.JWT;
using DndCharacterSheetAPI.Mapper;
using DndCharacterSheetAPI.Middleware;
using DndCharacterSheetAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressMapClientErrors = true;
});
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<JwtConfigurations>(builder.Configuration.GetSection("JwtConfigurations"));

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Authorize",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string> ()
        }
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration.GetSection("JwtConfigurations").GetValue<string>("Issuer"),
        ValidAudience = builder.Configuration.GetSection("JwtConfigurations").GetValue<string>("Audience"),
        ValidateAudience = true,
        ValidateIssuer = true,
        IssuerSigningKey = JwtConfigurations.GetSymmetricSecurityKey(builder.Configuration.GetSection("JwtConfigurations").GetValue<string>("Key")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        LifetimeValidator = (before, expires, token, parameters) =>
        {
            var utcNow = DateTime.UtcNow;
            return before <= utcNow && utcNow < expires;
        }
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Roles.Player.ToString(), p => p.RequireClaim("UserRole", Roles.Player.ToString()));
    options.AddPolicy(Roles.GameMaster.ToString(), p => p.RequireClaim("UserRole", Roles.GameMaster.ToString()));
    options.AddPolicy(Roles.Admin.ToString(), p => p.RequireClaim("UserRole", Roles.Admin.ToString()));
    options.AddPolicy("Privileged", p =>
    {
        p.RequireAssertion(context =>
        {
            return context.User.HasClaim(claim => (claim.Type == "UserRole" && claim.Value == Roles.GameMaster.ToString())
            || (claim.Type == "UserRole" && claim.Value == Roles.Admin.ToString())
            );
        });
    });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDictionaryService, DictionaryService>();
builder.Services.AddScoped<IExternalSystemService, ExternalSystemService>();
builder.Services.AddHttpClient<IExternalSystemService, ExternalSystemService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();

app.UseMiddleware<TokenCatchMiddleware>();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
