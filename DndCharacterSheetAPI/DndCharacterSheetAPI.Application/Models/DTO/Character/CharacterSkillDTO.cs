using DndCharacterSheetAPI.Application.Models.Enums;

namespace DndCharacterSheetAPI.Application.Models.DTO.Character
{
    public class CharacterSkillDTO
    {
        public string Name { get; set; }
        public Attributes AssociatedAttribute { get; set; }
        public int Value { get; set; }
        public bool IsProficient { get; set; }
    }
}
