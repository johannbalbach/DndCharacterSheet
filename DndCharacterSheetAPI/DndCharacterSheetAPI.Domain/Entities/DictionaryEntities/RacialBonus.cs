using DndCharacterSheetAPI.Application.Models.Enums;

namespace DndCharacterSheetAPI.Domain.Entities
{
    public class RacialBonus
    {
        public Guid Id { get; set; }
        public Attributes Attribute { get; set; }
        public int BonusValue { get; set; }
        public Guid RaceId { get; set; }
        public Race Race { get; set; }
    }
}
