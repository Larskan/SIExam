using Microsoft.AspNetCore.Mvc;
using StatusService.Interfaces;
using StatusService.Models;

namespace StatusService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusController(IStatusService statusService)
    {
        _statusService = statusService;
    }

    // GET: Resilience testing
    [HttpGet("test/skillservice/slow")]
    public async Task<ActionResult<string>> TestSkillServiceSlowEndpoint()
    {
        var response = await _statusService.CallSkillServiceSlowEndpointAsync();
        return Ok(response);
    }

    [HttpGet("test/skillservice/unreliable")]
    public async Task<ActionResult<string>> TestSkillServiceUnreliableEndpoint()
    {
        var response = await _statusService.CallSkillServiceUnreliableEndpointAsync();
        return Ok(response);
    }

    [HttpGet("test/skillservice/unstable")]
    public async Task<ActionResult<string>> TestSkillServiceUnstableEndpoint()
    {
        var response = await _statusService.CallSkillServiceUnstableEndpointAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Status?>> GetStatusById(int id)
    {
        var status = await _statusService.GetStatusByIdAsync(id);
        return status is null ? NotFound() : Ok(status);
    }

    [HttpPost]
    public async Task<ActionResult<Status>> CreateStatus(Status status)
    {
        var createdStatus = await _statusService.CreateStatusAsync(status);
        return CreatedAtAction(nameof(GetStatusById), new { id = createdStatus.Id }, createdStatus);
    }

    [HttpPost("{id}/experience")]
    public async Task<IActionResult> RegisterExperience(int id, [FromBody] int xpGained)
    {
        await _statusService.RegisterExperienceAsync(id, xpGained);
        return NoContent();
    }

    [HttpPost("{id}/stats")]
    public async Task<IActionResult> RegisterStats(int id, [FromQuery] int vitality, [FromQuery] int endurance, [FromQuery] int strength, [FromQuery] int intelligence, [FromQuery] int mentality, [FromQuery] int dexterity)
    {
        await _statusService.RegisterStatsAsync(id, vitality, endurance, strength, intelligence, mentality, dexterity);
        return NoContent();
    }
}