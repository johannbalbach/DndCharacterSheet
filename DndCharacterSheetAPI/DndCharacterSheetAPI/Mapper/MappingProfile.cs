using AutoMapper;
using DndCharacterSheetAPI.Application.Models.DTO.Dictionary;
using DndCharacterSheetAPI.Application.Models.DTO.User;
using DndCharacterSheetAPI.Domain.Entities;
using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;

namespace DndCharacterSheetAPI.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserWithId>();
            CreateMap<User, UserDTO>();
            CreateMap<Race, RaceDTO>().ReverseMap();
            CreateMap<Race, RaceWithIdDTO>().ReverseMap();
            CreateMap<Origin, OriginDTO>().ReverseMap();
            CreateMap<Origin, OriginWithIdDTO>().ReverseMap();
            CreateMap<OriginSkillProficiency, OriginSkillProficiencyDTO>().ReverseMap();
            CreateMap<OriginUniqueSkill, OriginUniqueSkillDTO>().ReverseMap();
            CreateMap<RacialBonus, RacialBonusDTO>().ReverseMap();
            CreateMap<RaceUniqueSkill, RaceUniqueSkillDTO>().ReverseMap();
        }
    }
}
