using AutoMapper;
using DndCharacterSheetAPI.Application.Models.DTO;
using DndCharacterSheetAPI.Domain.Entities;
using DndCharacterSheetAPI.Models.DTO;

namespace DndCharacterSheetAPI.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserWithId>();
            CreateMap<User, UserDTO>();
        }
    }
}
