using AutoMapper;
using DndCharacterSheetAPI.Application.Models.DTO.Character;
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
            CreateMap<Character, CharacterDTO>().ReverseMap();
            CreateMap<Character, CharacterFullViewModel>().ReverseMap();
            CreateMap<SavingThrow, SavingThrowDTO>().ReverseMap();
            CreateMap<CharacterSkill, CharacterSkillDTO>().ReverseMap();
            CreateMap<CharacterClass, CharacterClassDTO>().ReverseMap();
            CreateMap<CharacterClass, CharacterClassWithIdDTO>().ReverseMap();
            CreateMap<CharacterClassSkillProficiency, CharacterClassSkillProficiencyDTO>().ReverseMap();
            CreateMap<ClassLevelBonus, ClassLevelBonusDTO>().ReverseMap();
        }
    }
}
