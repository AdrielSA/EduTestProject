using EduTest.API.Responses;
using EduTest.Services.DTOs;
using EduTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EduTest.API.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> SignIn([FromBody] UserDto dto)
        {
            try
            {
                await _service.SignInUser(dto);
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn([FromBody] UserDto dto)
        {
            try
            {
                await _service.LogInUser(dto);
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _service.LogOutUser();
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("addrole")]
        public async Task<IActionResult> AddRole([FromBody] RoleDto dto)
        {
            try
            {
                await _service.RegisterRole(dto);
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
