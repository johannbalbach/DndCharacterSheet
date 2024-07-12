using DndCharacterSheetAPI.Application.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.Dictionary
{
    public class RacialBonusDTO
    {
        [Required]
        public Attributes Attribute { get; set; }
        [Required]
        public int BonusValue { get; set; }
    }
}
