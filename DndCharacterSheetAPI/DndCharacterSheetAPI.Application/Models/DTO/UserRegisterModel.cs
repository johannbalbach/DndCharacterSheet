using DndCharacterSheetAPI.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Models.DTO
{
    public class UserRegisterModel
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        [EnumDataType(typeof(Roles))]
        [Required]
        public Roles UserRole { get; set; }
    }
}
