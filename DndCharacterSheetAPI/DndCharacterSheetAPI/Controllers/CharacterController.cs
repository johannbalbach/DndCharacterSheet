using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Application.Models.DTO.Character;
using DndCharacterSheetAPI.Domain.Context;
using DndCharacterSheetAPI.Domain.Entities;
using DndCharacterSheetAPI.Models.DTO;
using DndCharacterSheetAPI.Models.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace DndCharacterSheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        [Authorize(Policy = "Privileged")]
        [Route("GetAllCharacters")]
        public async Task<CharactersList> GetAllCharacters()
        {
            return await _characterService.GetAllCharacters();
        }

        [HttpGet]
        [Authorize]
        [Route("GetCharacter/{id}")]
        public async Task<CharacterFullViewModel> GetCharacter([FromRoute] Guid id)
        {
            var usernameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name.ToString())?.Value;
            if (usernameClaim == null)
                throw new InvalidTokenException("Token not found");

            return await _characterService.GetCharacter(id);
        }

        [HttpPost]
        [Authorize]
        [Route("CreateCharacter")]
        public async Task<CharacterFullViewModel> CreateCharacter(CharacterDTO character)
        {
            var usernameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name.ToString())?.Value;
            if (usernameClaim == null)
                throw new InvalidTokenException("Token not found");

            return await _characterService.CreateCharacter(character, usernameClaim);
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateCharacter/{id}")]
        public async Task<Response> UpdateCharacter([FromRoute] Guid id, CharacterDTO character)
        {
            var usernameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name.ToString())?.Value;
            if (usernameClaim == null)
                throw new InvalidTokenException("Token not found");

            await _characterService.UpdateCharacter(id, character);
            return new Response { Status = "200", Message = "VSE OK" };
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteCharacter/{id}")]
        public async Task<Response> DeleteCharacter([FromRoute] Guid id)
        {
            var usernameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name.ToString())?.Value;
            if (usernameClaim == null)
                throw new InvalidTokenException("Token not found");

            await _characterService.DeleteCharacter(id);
            return new Response { Status = "200", Message = "VSE OK" };
        }
    }
}
