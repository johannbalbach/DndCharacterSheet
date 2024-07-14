using DndCharacterSheetAPI.Application.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class CharacterClassDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ArmorProficiency { get; set; }
        public string? WeaponProficiency { get; set; }
        public string? ToolsProficiency { get; set; }
        public string? Languages { get; set; }
        [Required]
        public int HitDice { get; set; } // Например, d8, d10 и т.д.
        [Required]
        public List<Attributes> Rescues { get; set; } = new List<Attributes>();
        public List<ClassLevelBonusDTO> LevelBonuses { get; set; } = new List<ClassLevelBonusDTO>();
        public List<CharacterClassSkillProficiencyDTO> ClassSkillProficiencies { get; set; } = new List<CharacterClassSkillProficiencyDTO>();
    }
}
