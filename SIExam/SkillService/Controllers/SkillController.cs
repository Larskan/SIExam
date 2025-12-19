using Microsoft.AspNetCore.Mvc;
using SkillService.DTOs;
using SkillService.Interfaces;


namespace SkillService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    // Testing Resilience for timeout
    [HttpGet("slow")]
    public async Task<ActionResult<string>> GetSlowResponse()
    {
        await Task.Delay(10000); // 10sec
        return Ok("This is a slow response from SkillService.");
    }

    // Testing resilience for retry and circuit breaker
    [HttpGet("unreliable")]
    public async Task<ActionResult<string>> GetUnreliableResponse()
    {
        // Simulate an unstable response
        var random = new Random();
        if (random.Next(1, 4) != 1) // 75% chance of failure
            return StatusCode(500, "Internal Server Error");

        return Ok("This is an unstable response from SkillService.");
    }

    // Testing resilience for retry and circuit breaker
    [HttpGet("unstable")]
    public async Task<ActionResult<string>> GetUnstable()
    {
        throw new HttpRequestException("Simulated transient error.");
    }

    // GET: api/Skill
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SkillDto>?>> GetAllSkills()
    {
        var skills = await _skillService.GetAllSkillsAsync();
        if (skills is null)
            return NotFound();

        return Ok(skills);
    }

    // POST: api/Skill
    [HttpPost]
    public async Task<ActionResult<SkillDto>> CreateSkill([FromBody] CreateSkillDto Dto)
    {
        var createdSkill = await _skillService.CreateSkillAsync(Dto);
        return CreatedAtAction(nameof(GetAllSkills), new { id = createdSkill.Id }, createdSkill);
    }

    // PATCH: api/Skill/{id}/level
    [HttpPatch("{id}/level")]
    public async Task<ActionResult<SkillDto?>> UpdateSkillLevel(int id, [FromBody] UpdateSkillLevelDto dto)
    {
        var updatedSkill = await _skillService.UpdateSkillWithLevelAsync(id, dto);
        if (updatedSkill is null)
            return NotFound();
        return Ok(updatedSkill);
    }

    // PATCH: api/Skill/{id}/mastery
    [HttpPatch("{id}/mastery")]
    public async Task<ActionResult<SkillDto?>> UpdateSkillMastery(int id, [FromBody] UpdateSkillMasteryDto dto)
    {
        var updatedSkill = await _skillService.UpdateSkillWithMasteryAsync(id, dto);
        if (updatedSkill is null)
            return NotFound(); 
        return Ok(updatedSkill);
    }
}