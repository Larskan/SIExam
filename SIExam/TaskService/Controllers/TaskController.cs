using Microsoft.AspNetCore.Mvc;
using TaskService.DTOs;
using TaskService.Interfaces;   

namespace TaskService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // GET: api/Task
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    // POST: api/Task
    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskDto dto)
    {
        var createdTask = await _taskService.CreateTaskAsync(dto);
        return CreatedAtAction(nameof(GetAllTasks), new { id = createdTask.Id }, createdTask);
    }

    // PATCH: api/Task/{id}/description
    [HttpPatch("{id}/description")]
    public async Task<ActionResult<TaskDto?>> UpdateTaskDescription(int id, [FromBody] UpdateTaskDescriptionDto dto)
    {
        var updatedTask = await _taskService.UpdateTaskDescriptionAsync(id, dto);
        if (updatedTask is null)
            return NotFound();
        return Ok(updatedTask);
    }

    // PATCH: api/Task/{id}/experience
    [HttpPatch("{id}/experience")]
    public async Task<ActionResult<TaskDto?>> UpdateTaskExperience(int id, [FromBody] UpdateTaskXpDto dto)
    {
        var updatedTask = await _taskService.UpdateTaskXPAsync(id, dto);
        if (updatedTask is null)
            return NotFound();
        return Ok(updatedTask);
    }

    // PATCH: api/Task/{id}/gains
    [HttpPatch("{id}/gains")]
    public async Task<ActionResult<TaskDto?>> UpdateTaskGains(int id, [FromBody] UpdateTaskGainsDto dto)
    {
        var updatedTask = await _taskService.UpdateTaskGainsAsync(id, dto);
        if (updatedTask is null)
            return NotFound();
        return Ok(updatedTask);
    }
}