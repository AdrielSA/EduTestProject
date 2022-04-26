using EduTest.Services.DTOs;
using EduTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EduTest.API.Controllers
{
    [Authorize(Policy = "AdminRequire")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = HttpContext.User;
                var courses = await _service.GetAllCoursesAsync();
                if (!courses.Any())
                    return NoContent();
                return Ok(courses);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var course = await _service.GetCourseAsync(id);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] CourseDto course)
        {
            try
            {
                await _service.AddCourseAsync(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CourseDto course)
        {
            try
            {
                await _service.UpdateCourseAsync(id, course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            try
            {
                await _service.RemoveCourseAsync(id);
                return Ok(new { Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
