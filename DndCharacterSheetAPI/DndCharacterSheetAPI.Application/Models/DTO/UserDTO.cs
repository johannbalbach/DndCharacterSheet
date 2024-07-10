using DndCharacterSheetAPI.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Models.DTO
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public Roles UserRole { get; set; }
    }
}
