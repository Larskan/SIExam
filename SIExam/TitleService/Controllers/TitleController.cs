using Microsoft.AspNetCore.Mvc;
using TitleService.Interfaces;
using TitleService.DTOs;

namespace TitleService.Controllers;

// Why Patch instead of Put: I am updating specific fields of the Title resource without replacing the entire resource. 
// Put is generally used for full updates, whereas Patch is more suitable for partial updates.

[ApiController]
[Route("api/[controller]")]
public class TitleController : ControllerBase
{
    private readonly ITitleService _titleService;

    public TitleController(ITitleService titleService)
    {
        _titleService = titleService;
    }

    // GET: api/Title
    [HttpGet]
    public async Task<ActionResult<List<TitleDto>>> GetAllTitles()
    {
        var titles = await _titleService.GetAllTitlesAsync();
        if (titles is null)
            return NoContent(); //204
        return Ok(titles); //200
    }

    // POST: api/Title
    [HttpPost]
    public async Task<ActionResult<TitleDto>> CreateTitle([FromBody] CreateTitleDto dto)
    {
        var createdTitle = await _titleService.CreateTitleAsync(dto);
        return CreatedAtAction(nameof(GetAllTitles), new { id = createdTitle.Id }, createdTitle); //201
    }

    // Patch: api/Title/{id}/name
    [HttpPatch("{id}/name")]
    public async Task<ActionResult<TitleDto>> UpdateTitleName(int id, [FromBody] UpdateTitleNameDto dto)
    {
        var updatedTitle = await _titleService.UpdateTitleNameAsync(id, dto);
        if (updatedTitle is null)
            return NotFound(); //404
        return Ok(updatedTitle); //200
    }

    // Patch: api/Title/{id}/description
    [HttpPatch("{id}/description")]
    public async Task<ActionResult<TitleDto>> UpdateTitleDescription(int id, [FromBody] UpdateTitleDescriptionDto dto)
    {
        var updatedTitle = await _titleService.UpdateTitleDescriptionAsync(id, dto);
        if (updatedTitle is null)
            return NotFound(); //404
        return Ok(updatedTitle); //200
    }

    // Patch: api/Title/{id}/gains
    [HttpPatch("{id}/gains")]
    public async Task<ActionResult<TitleDto>> UpdateTitleGains(int id, [FromBody] UpdateTitleGainsDto dto)
    {
        var updatedTitle = await _titleService.UpdateTitleGainsAsync(id, dto);
        if (updatedTitle is null)
            return NotFound(); //404
        return Ok(updatedTitle); //200
    }

    // Patch: api/Title/{id}/tier
    [HttpPatch("{id}/tier")]
    public async Task<ActionResult<TitleDto>> UpdateTitleTier(int id, [FromBody] UpdateTitleTierDto dto)
    {
        var updatedTitle = await _titleService.UpdateTitleTierAsync(id, dto);
        if (updatedTitle is null)
            return NotFound(); //404
        return Ok(updatedTitle); //200
    }
}
