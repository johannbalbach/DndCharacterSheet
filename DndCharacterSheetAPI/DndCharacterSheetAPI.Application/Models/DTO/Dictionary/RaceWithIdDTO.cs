using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class RaceWithIdDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Speed { get; set; }
        public List<RacialBonusDTO> RacialBonuses { get; set; } = new List<RacialBonusDTO>();
        public List<RaceUniqueSkillDTO> RacicalSkills { get; set; } = new List<RaceUniqueSkillDTO>();
    }
}
