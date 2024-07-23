using DndCharacterSheetAPI.Application.Enums;
using DndCharacterSheetAPI.Application.Models.DTO.Character;

namespace DndCharacterSheetAPI.Application.Models.DTO.User
{
    public class UserWithId
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Roles UserRole { get; set; }
        public List<Guid> characters { get; set; } = new List<Guid>();
    }
    public class UsersList
    {
        public List<UserWithId> Users { get; set; } = new List<UserWithId>();
    }
}
