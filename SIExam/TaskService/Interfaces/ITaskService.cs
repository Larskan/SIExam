using TaskService.DTOs;

namespace TaskService.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetAllTasksAsync();
    Task<TaskDto> CreateTaskAsync(CreateTaskDto dto);
    Task<TaskDto?> UpdateTaskDescriptionAsync(int id, UpdateTaskDescriptionDto dto);
    Task<TaskDto?> UpdateTaskXPAsync(int id, UpdateTaskXpDto dto);
    Task<TaskDto?> UpdateTaskGainsAsync(int id, UpdateTaskGainsDto dto);
}