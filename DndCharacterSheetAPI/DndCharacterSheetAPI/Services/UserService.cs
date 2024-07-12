using AutoMapper;
using DndCharacterSheetAPI.Application.Enums;
using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Application.Models.DTO;
using DndCharacterSheetAPI.Application.Models.DTO.User;
using DndCharacterSheetAPI.Domain.Context;
using DndCharacterSheetAPI.Domain.Entities;
using DndCharacterSheetAPI.JWT;
using DndCharacterSheetAPI.Models.DTO;
using DndCharacterSheetAPI.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DndCharacterSheetAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TokenResponse> Register(UserRegisterModel userDto)
        {
            var user = new User
            {
                Id = new Guid(),
                UserName = userDto.UserName.Normalize(),
                Password = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(userDto.Password))),
                UserRole = userDto.UserRole
            };

            if (await _IsUserInDb(user))
            {
                throw new BadRequestException("user with that email is already in database");
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return await Login(new LoginCredentials
            {
                UserName = user.UserName,
                Password = userDto.Password,
            });
        }

        public async Task<TokenResponse> Login(LoginCredentials login)
        {
            login.Password = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(login.Password)));

            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == login.UserName);

            if (user == null)
                throw new InvalidLoginException();

            if (user.Password != login.Password)
                throw new BadRequestException("wrong password, pls try again");

            var token = JwtHelper.GetNewToken(login.UserName, JwtConfigurations.AccessLifeTime, user.UserRole);

            return new TokenResponse { AccessToken = token };
        }

        public async Task<UsersList> GetListOfUsers()
        {
            var totalUsersCount = await _context.Users.CountAsync();

            if (totalUsersCount == 0)
                throw new Exception("total users count is 0");

            var users = await _context.Users.ToListAsync();

            var userWithIds = new List<UserWithId>();
            users.ForEach(u => userWithIds.Add(_mapper.Map<UserWithId>(u)));

            return new UsersList { Users = userWithIds };
        }

        public async Task<Response> ChangeRole(Guid userId, Roles role)
        {
            var user = await _context.Users.SingleOrDefaultAsync(h => h.Id == userId);

            if (user == null)
                throw new NotFoundException("user with that guid doesnt exist");

            user.UserRole = role;
            await _context.SaveChangesAsync();

            return new Response { Message = "role successfully changed" };
        }

        private async Task<bool> _IsUserInDb(User user)
        {
            if (user == null)
                return false;

            var temp = await _context.Users.SingleOrDefaultAsync(h => h.UserName == user.UserName);

            return temp != null;
        }
    }
}
