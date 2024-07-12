using DndCharacterSheetAPI.Application.Enums;
using DndCharacterSheetAPI.Application.Models.DTO;
using DndCharacterSheetAPI.Application.Models.DTO.User;
using DndCharacterSheetAPI.Models.DTO;

namespace DndCharacterSheetAPI.Application.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponse> Register(UserRegisterModel userDto);
        Task<TokenResponse> Login(LoginCredentials login);
        Task<UsersList> GetListOfUsers();
        Task<Response> ChangeRole(Guid userId, Roles role);
    }
}
