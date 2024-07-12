using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class RaceUniqueSkillDTO
    {
        [Required]
        public string SkillName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
