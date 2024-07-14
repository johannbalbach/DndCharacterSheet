using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DndCharacterSheetAPI.Application.Models.DTO.Character
{
    public class CharacterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid CharacterClassId { get; set; }
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int ProficiencyBonus { get; set; } = 2;
        [Required]
        public Guid RaceId { get; set; }
        [Required]
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
    }
}
