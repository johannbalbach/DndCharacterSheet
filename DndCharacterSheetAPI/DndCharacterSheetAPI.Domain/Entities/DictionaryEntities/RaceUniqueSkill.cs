namespace DndCharacterSheetAPI.Domain.Entities.DictionaryEntities
{
    public class RaceUniqueSkill
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        public string Description { get; set; }
        public Guid RaceId { get; set; }
        public Race Race { get; set; } = null!;
    }
}
