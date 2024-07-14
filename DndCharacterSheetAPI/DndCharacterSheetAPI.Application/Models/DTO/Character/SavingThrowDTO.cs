using DndCharacterSheetAPI.Application.Models.Enums;

namespace DndCharacterSheetAPI.Application.Models.DTO.Character
{
    public class SavingThrowDTO
    {
        public Attributes AssociatedAttribute { get; set; }
        public int Value { get; set; }
        public bool IsProficient { get; set; }
    }
}
