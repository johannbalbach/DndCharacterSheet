using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;

namespace DndCharacterSheetAPI.Domain.Entities
{
    public class CharacterSkill
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public int Value { get; set; }
        public bool IsProficient { get; set; }
    }
}
