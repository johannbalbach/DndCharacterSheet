using DndCharacterSheetAPI.Application.Enums;

namespace DndCharacterSheetAPI.Application.Models.DTO.User
{
    public class UserWithId
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Roles UserRole { get; set; }
    }
    public class UsersList
    {
        public List<UserWithId> Users { get; set; } = new List<UserWithId>();
    }
}
