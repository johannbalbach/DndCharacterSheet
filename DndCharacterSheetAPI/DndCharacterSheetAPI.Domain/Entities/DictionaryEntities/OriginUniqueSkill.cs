namespace DndCharacterSheetAPI.Domain.Entities
{
    //уникальные умения в текстовом виде
    public class OriginUniqueSkill
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        public string Description { get; set; }
        public Guid OriginId { get; set; }
        public Origin Origin { get; set; } = null!;
    }
}
