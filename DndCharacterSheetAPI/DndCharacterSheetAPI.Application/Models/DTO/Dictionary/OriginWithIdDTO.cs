using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class OriginWithIdDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Equipment { get; set; }
        public string? EquipmentProficiency { get; set; }
        public string? Languages { get; set; }
        public List<OriginSkillProficiencyDTO> OriginSkillProficiencies { get; set; } = new List<OriginSkillProficiencyDTO>();
        public List<OriginUniqueSkillDTO> OriginUniqueSkills { get; set; } = new List<OriginUniqueSkillDTO>();
    }
}
