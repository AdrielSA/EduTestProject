using EduTest.API.Responses;
using EduTest.Services.DTOs;
using EduTest.Services.Interfaces;
using EduTest.Services.QueryFilters;
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
    public class MatterController : ControllerBase
    {
        private readonly IMatterService _service;

        public MatterController(IMatterService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll([FromQuery] MatterQueryFilter filter)
        {
            try
            {
                var matters = await _service.GetAllMattersAsync(filter);
                if (!matters.Any())
                    return NoContent();
                var response = new ApiResponse<IEnumerable<MatterDto>> { Content = matters };
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
                var matter = await _service.GetMatterAsync(id);
                var response = new ApiResponse<MatterDto> { Content = matter };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] MatterDto matter)
        {
            try
            {
                await _service.AddMatterAsync(matter);
                var response = new ApiResponse<MatterDto> { Content = matter };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MatterDto matter)
        {
            try
            {
                await _service.UpdateMatterAsync(id, matter);
                var response = new ApiResponse<MatterDto> { Content = matter };
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
                await _service.RemoveMatterAsync(id);
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
