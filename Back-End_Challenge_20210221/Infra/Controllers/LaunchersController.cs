using Back_End_Challenge_20210221.Domain.Data;
using Back_End_Challenge_20210221.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_End_Challenge_20210221.Infra.Controllers
{
    [Authorize]
    [Route("launchers")]
    [ApiController]
    public class LaunchersController : ControllerBase
    {
        private readonly ILaunchData _launchData;

        public LaunchersController(ILaunchData launchData)
        {
            _launchData = launchData;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                var result = await _launchData.GetAllAsync(skip, take);
                var count = await _launchData.CountAsync();
                var currentPage = skip / take + 1;
                var totalPages = count / take;

                return Ok(new
                {
                    count,
                    skip,
                    take,
                    currentPage,
                    totalPages,
                    results = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var result = await _launchData.GetAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, Launch launch)
        {
            if (id != launch.Id)
                return BadRequest();

            try
            {
                await _launchData.PutAsync(id, launch);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _launchData.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
