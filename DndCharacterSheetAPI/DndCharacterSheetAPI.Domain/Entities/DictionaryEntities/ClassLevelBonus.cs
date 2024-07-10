namespace DndCharacterSheetAPI.Domain.Entities.DictionaryEntities
{
    public class ClassLevelBonus
    {
        public Guid Id { get; set; }
        public int Level { get; set; }
        public int HitPointsBonus { get; set; }
        public string SpecialAbilities { get; set; } // Уникальные умения, получаемые на этом уровне
        public Guid CharacterClassId { get; set; }
        public CharacterClass CharacterClass { get; set; } = null!;
    }
}
