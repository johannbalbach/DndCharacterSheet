using DndCharacterSheetAPI.Application.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class CharacterClassWithIdDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ArmorProficiency { get; set; }
        public string? WeaponProficiency { get; set; }
        public string? ToolsProficiency { get; set; }
        public string? Languages { get; set; }
        public int HitDice { get; set; } // Например, d8, d10 и т.д.
        public List<Attributes> Rescues { get; set; } = new List<Attributes>();
        public List<ClassLevelBonusDTO> LevelBonuses { get; set; } = new List<ClassLevelBonusDTO>();
        public List<CharacterClassSkillProficiencyDTO> ClassSkillProficiencies { get; set; } = new List<CharacterClassSkillProficiencyDTO>();
    }
}
