using EduTest.Services.DTOs;
using System.Threading.Tasks;

namespace EduTest.Services.Interfaces
{
    public interface IAuthService
    {
        Task LogInUser(LoginDto dto);
        Task LogOutUser();
        Task RegisterRole(RoleDto dto);
        Task SignInUser(RegisterDto dto);
    }
}