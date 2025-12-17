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

    // PUT: api/Skill/{id}/level
    [HttpPut("{id}/level")]
    public async Task<ActionResult<SkillDto?>> UpdateSkillLevel(int id, [FromBody] UpdateSkillLevelDto dto)
    {
        var updatedSkill = await _skillService.UpdateSkillWithLevelAsync(id, dto);
        if (updatedSkill is null)
            return NotFound();
        return Ok(updatedSkill);
    }

    // PUT: api/Skill/{id}/mastery
    [HttpPut("{id}/mastery")]
    public async Task<ActionResult<SkillDto?>> UpdateSkillMastery(int id, [FromBody] UpdateSkillMasteryDto dto)
    {
        var updatedSkill = await _skillService.UpdateSkillWithMasteryAsync(id, dto);
        if (updatedSkill is null)
            return NotFound(); 
        return Ok(updatedSkill);
    }
}