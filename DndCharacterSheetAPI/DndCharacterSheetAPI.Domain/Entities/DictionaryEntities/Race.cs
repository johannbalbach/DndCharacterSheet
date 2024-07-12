using DndCharacterSheetAPI.Domain.Entities.DictionaryEntities;

namespace DndCharacterSheetAPI.Domain.Entities
{
    public class Race
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Speed { get; set; } = 30;
        public List<RacialBonus> RacialBonuses { get; set; } = new List<RacialBonus>();
        public List<RaceUniqueSkill> RacicalSkills { get; set; } = new List<RaceUniqueSkill>();
    }
}
    