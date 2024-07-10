using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;

namespace DndCharacterSheetAPI.Domain.Entities
{
    //владение навыками 
    public class OriginSkillProficiency
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
        public int Value { get; set; }
        public Guid OriginId { get; set; }
        public Origin Origin { get; set; } = null!;
    }
}
