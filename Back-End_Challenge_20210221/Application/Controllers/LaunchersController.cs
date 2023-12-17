using Back_End_Challenge_20210221.Domain.Data;
using Back_End_Challenge_20210221.Domain.Models;
using Back_End_Challenge_20210221.Domain.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_End_Challenge_20210221.Application.Controllers;

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
            var count = await _launchData.CountUnlikeTrashAsync();
            var currentPage = skip / take + 1;
            var totalPages = count % take != 0 ? count / take + 1 : count / take;

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

            if (result.Status != Import_Status.Trash)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Deleted locally.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(Guid id, Launch launch)
    {
        if (id == launch.Id)
        {
            try
            {
                await _launchData.PutAsync(id, launch);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        else
        {
            return BadRequest("The id does not match the object.");
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
