using DndCharacterSheetAPI.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Application.Models.DTO.User
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public Roles UserRole { get; set; }
    }
}
