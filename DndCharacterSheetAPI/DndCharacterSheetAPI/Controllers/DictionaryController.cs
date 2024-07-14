using DndCharacterSheetAPI.Application.Interfaces;
using DndCharacterSheetAPI.Application.Models.DTO.Character;
using DndCharacterSheetAPI.Application.Models.DTO.Dictionary;
using DndCharacterSheetAPI.Domain.Entities;
using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;
using DndCharacterSheetAPI.Models.DTO;
using DndCharacterSheetAPI.Models.Exceptions;
using DndCharacterSheetAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DndCharacterSheetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryService _dictionaryService;

        public DictionaryController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllSkills")]
        public async Task<List<Skill>> GetAllSkills()
        {
            var skills = await _dictionaryService.GetAll<Skill, Skill>();
            return skills;
        }


        [HttpGet]
        [Authorize]
        [Route("GetAllRaces")]
        public async Task<List<RaceWithIdDTO>> GetAllRaces()
        {
            var races = await _dictionaryService.GetAll<Race, RaceWithIdDTO>(r => r.RacialBonuses, r => r.RacicalSkills);
            return races;
        }

        [HttpGet]
        [Authorize]
        [Route("GetRace/{id}")]
        public async Task<RaceWithIdDTO> GetRace([FromRoute] Guid id)
        {
            var race = await _dictionaryService.GetById<Race, RaceWithIdDTO>(id, r => r.RacialBonuses, r => r.RacicalSkills);
            return race;
        }

        [HttpPost]
        [Authorize]
        [Route("CreateRace")]
        public async Task<RaceWithIdDTO> CreateRace(RaceDTO race)
        {
            var createdRace = await _dictionaryService.Create<Race, RaceDTO, RaceWithIdDTO>(race);
            return createdRace;
        }

        [HttpPut]
        [Authorize(Policy = "Privileged")]
        [Route("UpdateRace/{id}")]
        public async Task<Response> UpdateRace([FromRoute] Guid id, RaceDTO race)
        {
            await _dictionaryService.Update<Race, RaceDTO>(id, race);
            return new Response { Status = "200", Message = "VSE OK" };
        }

        [HttpDelete]
        [Authorize(Policy = "Privileged")]
        [Route("DeleteRace/{id}")]
        public async Task<Response> DeleteRace([FromRoute] Guid id)
        {
            await _dictionaryService.Delete<Race>(id);
            return new Response { Status = "200", Message = "VSE OK" };
        }
        [HttpGet]
        [Authorize]
        [Route("GetAllOrigins")]
        public async Task<List<OriginWithIdDTO>> GetAllOrigins()
        {
            var origins = await _dictionaryService.GetAll<Origin, OriginWithIdDTO>(r => r.OriginSkillProficiencies, r => r.OriginUniqueSkills);
            return origins;
        }

        [HttpGet]
        [Authorize]
        [Route("GetOrigin/{id}")]
        public async Task<OriginWithIdDTO> GetOrigin([FromRoute] Guid id)
        {
            var origin = await _dictionaryService.GetById<Origin, OriginWithIdDTO>(id, r => r.OriginSkillProficiencies, r => r.OriginUniqueSkills);
            return origin;
        }

        [HttpPost]
        [Authorize]
        [Route("CreateOrigin")]
        public async Task<OriginWithIdDTO> CreateOrigin(OriginDTO origin)
        {
            var createdOrigin = await _dictionaryService.Create<Origin, OriginDTO, OriginWithIdDTO>(origin);
            return createdOrigin;
        }

        [HttpPut]
        [Authorize(Policy = "Privileged")]
        [Route("UpdateOrigin/{id}")]
        public async Task<Response> UpdateOrigin([FromRoute] Guid id, OriginDTO origin)
        {
            await _dictionaryService.Update<Origin, OriginDTO>(id, origin);
            return new Response { Status = "200", Message = "VSE OK" };
        }

        [HttpDelete]
        [Authorize(Policy = "Privileged")]
        [Route("DeleteOrigin/{id}")]
        public async Task<Response> DeleteOrigin([FromRoute] Guid id)
        {
            await _dictionaryService.Delete<Origin>(id);
            return new Response { Status = "200", Message = "VSE OK" };
        }
        [HttpGet]
        [Authorize]
        [Route("GetAllClasses")]
        public async Task<List<CharacterClassWithIdDTO>> GetAllClasses()
        {
            return await _dictionaryService.GetAll<CharacterClass, CharacterClassWithIdDTO>(
                cc => cc.LevelBonuses, cc => cc.ClassSkillProficiencies);
        }

        [HttpGet]
        [Authorize]
        [Route("GetClass/{id}")]
        public async Task<CharacterClassWithIdDTO> GetClass([FromRoute] Guid id)
        {
            return await _dictionaryService.GetById<CharacterClass, CharacterClassWithIdDTO>(
                id, cc => cc.LevelBonuses, cc => cc.ClassSkillProficiencies);
        }

        [HttpPost]
        [Authorize]
        [Route("CreateClass")]
        public async Task<CharacterClassWithIdDTO> CreateClass(CharacterClassDTO characterClassDto)
        {
            return await _dictionaryService.Create<CharacterClass, CharacterClassDTO, CharacterClassWithIdDTO>(characterClassDto);
        }

        [HttpPut]
        [Authorize(Policy = "Previleged")]
        [Route("UpdateClass/{id}")]
        public async Task<Response> UpdateClass([FromRoute] Guid id, CharacterClassDTO characterClassDto)
        {
            await _dictionaryService.Update<CharacterClass, CharacterClassDTO>(id, characterClassDto);
            return new Response { Status = "200", Message = "VSE OK" };
        }

        [HttpDelete]
        [Authorize(Policy = "Previleged")]
        [Route("DeleteClass/{id}")]
        public async Task<Response> DeleteClass([FromRoute] Guid id)
        {
            await _dictionaryService.Delete<CharacterClass>(id);
            return new Response { Status = "200", Message = "VSE OK" };
        }
    }
}
