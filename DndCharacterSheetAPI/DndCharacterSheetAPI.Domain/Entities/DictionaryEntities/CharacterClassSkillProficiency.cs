
namespace DndCharacterSheetAPI.Domain.Entities.DictionaryEntities
{
    public class CharacterClassSkillProficiency
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public Guid CharacterClassId { get; set; }
        public CharacterClass CharacterClass { get; set; } = null!;
    }
}
