using DndCharacterSheetAPI.Application.Models.DTO.Character;

namespace DndCharacterSheetAPI.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<CharactersList> GetAllCharacters();
        Task<CharacterFullViewModel> GetCharacter(Guid id);
        Task<CharacterFullViewModel> CreateCharacter(CharacterDTO characterDto);
        Task UpdateCharacter(Guid id, CharacterDTO characterDto);
        Task DeleteCharacter(Guid id);
    }
}
