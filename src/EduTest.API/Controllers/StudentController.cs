using EduTest.API.Responses;
using EduTest.Services.DTOs;
using EduTest.Services.Interfaces;
using EduTest.Services.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll([FromQuery] StudentQueryFilter filter)
        {
            try
            {
                var result = await _service.GetAllStudentsAsync(filter);
                var students = result.Item1;
                var metaData = result.Item2;
                if (!students.Any()) 
                    return NoContent();
                Response.Headers.Add("pagination", JsonConvert.SerializeObject(metaData));
                var response = new ApiResponse<IEnumerable<StudentDto>>
                {
                    Success = true,
                    Content = students,
                    MetaData = metaData
                };
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
                var student = await _service.GetStudentAsync(id);
                var response = new ApiResponse<StudentDto> { Content = student };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] StudentDto student)
        {
            try
            {
                await _service.AddStudentAsync(student);
                var response = new ApiResponse<StudentDto> { Content = student };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentDto student)
        {
            try
            {
                await _service.UpdateStudentAsync(id, student);
                var response = new ApiResponse<StudentDto> { Content = student };
                return Ok(response);
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
                await _service.RemoveStudentAsync(id);
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
