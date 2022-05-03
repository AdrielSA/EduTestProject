using EduTest.Domain.Exceptions;
using EduTest.Services.DTOs;
using EduTest.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EduTest.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task SignInUser(RegisterDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                EmailConfirmed = true,
                PasswordHash = dto.Password
            };
            var userResult = await _userManager.CreateAsync(user, dto.Password);
            if (!userResult.Succeeded)
                throw new ApiException(userResult.Errors);
            var roleResult = await _userManager.AddToRoleAsync(user, dto.Role);
            if (!roleResult.Succeeded)
                throw new ApiException(roleResult.Errors);
            await LogInUser(new LoginDto { UserName = dto.UserName, Password = dto.Password }) ;
        }

        public async Task LogInUser(LoginDto dto)
        {
            var exist = await _userManager.FindByNameAsync(dto.UserName);
            if (exist == null)
                throw new ApiException("El usuario NO existe.");
            var signInResult = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);
            if (!signInResult.Succeeded)
                throw new ApiException("Hubo un error");
        }

        public async Task LogOutUser() => await _signInManager.SignOutAsync();

        public async Task RegisterRole(RoleDto dto)
        {
            var exist = await _roleManager.RoleExistsAsync(dto.Name);
            if (exist)
                throw new ApiException("El rol ya existe.");
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = dto.Name });
            if (!result.Succeeded)
                throw new ApiException(result.Errors);
        }
    }
}
