using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class RaceDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Speed { get; set; } = 30;
        public List<RacialBonusDTO> RacialBonuses { get; set; } = new List<RacialBonusDTO>();
        public List<RaceUniqueSkillDTO> RacicalSkills { get; set; } = new List<RaceUniqueSkillDTO>();
    }
}
