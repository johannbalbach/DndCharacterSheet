using DndCharacterSheetAPI.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace DndCharacterSheetAPI.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles UserRole { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
