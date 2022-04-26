using EduTest.Services.DTOs;
using System.Threading.Tasks;

namespace EduTest.Services.Interfaces
{
    public interface IAuthService
    {
        Task LogInUser(UserDto dto);
        Task LogOutUser();
        Task RegisterRole(RoleDto dto);
        Task SignInUser(UserDto dto);
    }
}