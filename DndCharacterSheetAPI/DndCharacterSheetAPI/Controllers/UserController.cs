using AutoMapper;
using DndCharacterSheetAPI.Application.Enums;
using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Application.Models.DTO;
using DndCharacterSheetAPI.Application.Models.DTO.User;
using DndCharacterSheetAPI.Models.DTO;
using DndCharacterSheetAPI.Models.Exceptions;
using DndCharacterSheetAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DndCharacterSheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<TokenResponse>> Register(UserRegisterModel userDto)
        {
            return await _userService.Register(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginCredentials login)
        {
            return await _userService.Login(login);
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<UsersList>> GetListOfUsers()
        {
            return await _userService.GetListOfUsers();
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<Response>> ChangeRole(Guid userId, Roles role)
        {
            return await _userService.ChangeRole(userId, role);
        }
    }
}
