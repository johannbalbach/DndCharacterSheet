using DndCharacterSheetAPI.Application.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DndCharacterSheetAPI.JWT
{
    public static class JwtHelper
    {
        public static ClaimsIdentity GetClaimsIdentity(string userName, Roles userRole)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, userName),
                new Claim("UserRole", userRole.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });
        }

        public static string GetNewToken(string userName, JwtConfigurations _jwtConfiguration, Roles userRole = Roles.Player)
        {
            var issuer = _jwtConfiguration.Issuer;
            var audience = _jwtConfiguration.Audience;
            var lifeTime = _jwtConfiguration.AccessLifeTime;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(userName, userRole),
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddMinutes(lifeTime),
                SigningCredentials = new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(_jwtConfiguration.Key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }

        public static JwtSecurityToken DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken;
        }
    }
}

