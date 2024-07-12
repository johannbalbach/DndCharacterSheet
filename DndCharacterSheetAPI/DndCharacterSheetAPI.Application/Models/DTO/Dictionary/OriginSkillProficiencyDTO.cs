using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class OriginSkillProficiencyDTO
    {
        [Required]
        public Guid SkillId { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
