using EduTest.API.Responses;
using EduTest.Services.DTOs;
using EduTest.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduTest.API.Controllers
{
    [Authorize]
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
                var courses = await _service.GetAllCoursesAsync();
                if (!courses.Any())
                    return NoContent();
                var response = new ApiResponse<IEnumerable<CourseDto>> { Content = courses };
                return Ok(response);

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
                var response = new ApiResponse<CourseDto> { Content = course };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Policy = "AdminRequire")]
        public async Task<IActionResult> Add([FromBody] CourseDto course)
        {
            try
            {
                await _service.AddCourseAsync(course);
                var response = new ApiResponse<CourseDto> { Content = course };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        [Authorize(Policy = "AdminRequire")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CourseDto course)
        {
            try
            {
                await _service.UpdateCourseAsync(id, course);
                var response = new ApiResponse<CourseDto> { Content = course };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("remove/{id}")]
        [Authorize(Policy = "AdminRequire")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            try
            {
                await _service.RemoveCourseAsync(id);
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
