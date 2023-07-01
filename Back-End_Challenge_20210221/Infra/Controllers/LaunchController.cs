using Back_End_Challenge_20210221.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace Back_End_Challenge_20210221.Infra.Controllers
{
    [Route("launch")]
    [ApiController]
    public class LaunchController : ControllerBase
    {
        private readonly ILaunchData _launchData;

        public LaunchController(ILaunchData launchData)
        {
            _launchData = launchData;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _launchData.GetAllAsync(0, 10);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{id}")]
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

        [HttpDelete("/{id}")]
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

        [HttpDelete]
        public async Task<IActionResult> DeleteAllAsync()
        {
            try
            {
                await _launchData.DeleteAllAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
