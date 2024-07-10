using DndCharacterSheetAPI.Application.Models.Enums;

namespace DndCharacterSheetAPI.Domain.Entities
{
    public class SavingThrow
    {
        public Guid Id { get; set; }
        public Attributes AssociatedAttribute { get; set; }
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
        public int Value { get; set; }
        public bool IsProficient { get; set; }
    }
}
