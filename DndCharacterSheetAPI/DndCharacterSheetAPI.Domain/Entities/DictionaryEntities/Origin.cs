namespace DndCharacterSheetAPI.Domain.Entities
{
    public class Origin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Equipment { get; set; }
        public string EquipmentProficiency {  get; set; }
        public string Languages {  get; set; }
        public List<OriginSkillProficiency> OriginSkillProficiencies { get; set; } = new List<OriginSkillProficiency>();
        public List<OriginUniqueSkill> OriginUniqueSkills { get; set; } = new List<OriginUniqueSkill>();
    }

}
