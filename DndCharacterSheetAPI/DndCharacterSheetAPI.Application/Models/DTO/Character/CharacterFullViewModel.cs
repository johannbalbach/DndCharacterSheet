using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Character
{
    public class CharacterFullViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CharacterClassId { get; set; }
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int ProficiencyBonus { get; set; } = 2;
        public Guid RaceId { get; set; }
        public Guid OriginId { get; set; }
        public string? OutlookText { get; set; }
        public int Strength { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Constitution { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public int Wisdom { get; set; } = 10;
        public int Charisma { get; set; } = 10;
        public string? Age { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? Eyes { get; set; }
        public string? Skin { get; set; }
        public string? Hair { get; set; }
        public List<string> Notes { get; set; } = new List<string>();
        public List<CharacterSkillDTO> Skills { get; set; } = new List<CharacterSkillDTO>();
        public List<SavingThrowDTO> SavingThrows { get; set; } = new List<SavingThrowDTO>();
    }
}
