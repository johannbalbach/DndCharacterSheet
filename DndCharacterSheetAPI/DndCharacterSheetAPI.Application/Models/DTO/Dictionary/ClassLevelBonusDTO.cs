namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class ClassLevelBonusDTO
    {
        public int Level { get; set; }
        public int ProficiencyBonusValue { get; set; }
        public string SpecialAbilities { get; set; } // Уникальные умения, получаемые на этом уровне
    }
}
