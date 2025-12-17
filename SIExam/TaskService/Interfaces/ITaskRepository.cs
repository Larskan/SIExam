using TaskService.Models;

namespace TaskService.Interfaces;


public interface ITaskRepository
{
    Task<List<Models.Task>?> GetAllTasksAsync();
    Task<Models.Task> CreateTaskAsync(Models.Task task);
    Task<Models.Task?> UpdateTaskDescriptionAsync(int id, string description);
    Task<Models.Task?> UpdateTaskExperienceAsync(int id, int xp);
    Task<Models.Task?> UpdateTaskGainsAsync(int id, Models.Task task);
}