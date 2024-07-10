namespace DndCharacterSheetAPI.Domain.Entities.DictionaryEntities
{
    public class CharacterClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ArmorProficiency { get; set; }
        public string WeaponProficiency { get; set; }
        public string ToolsProficiency { get; set; }
        public string Languages { get; set; }
        public int HitDice { get; set; } // Например, d8, d10 и т.д.
        public List<Attribute> Rescues { get; set; } = new List<Attribute>();
        public List<ClassLevelBonus> LevelBonuses { get; set; } = new List<ClassLevelBonus>();
        public List<CharacterClassSkillProficiency> ClassSkillProficiencies { get; set; } = new List<CharacterClassSkillProficiency>();
    }
}
