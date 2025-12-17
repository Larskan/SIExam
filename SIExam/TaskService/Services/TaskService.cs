using TaskService.Data;
using TaskService.Interfaces;
using TaskService.DTOs;

namespace TaskService.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await _taskRepository.GetAllTasksAsync();

        if (tasks is null || tasks.Count == 0)
            return Enumerable.Empty<TaskDto>();

        return tasks.Select(t => t.ToDto());
    }

    public async Task<TaskDto> CreateTaskAsync(CreateTaskDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Description))
            throw new ArgumentException("Task description cannot be empty.");
        
        var task = new Models.Task
        {
            StatusId = dto.StatusId,
            Description = dto.Description,
            Experience = dto.Experience,
            VitalityGain = dto.VitalityGain,
            EnduranceGain = dto.EnduranceGain,
            StrengthGain = dto.StrengthGain,
            IntelligenceGain = dto.IntelligenceGain,
            MentalityGain = dto.MentalityGain,
            DexterityGain = dto.DexterityGain
        };

        var createdTask = await _taskRepository.CreateTaskAsync(task);
        return createdTask.ToDto();
    }
    public async Task<TaskDto?> UpdateTaskDescriptionAsync(int id, UpdateTaskDescriptionDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Description))
            throw new ArgumentException("Task description cannot be empty.");
        
        var updatedTask = await _taskRepository.UpdateTaskDescriptionAsync(id, dto.Description);
        return updatedTask?.ToDto();
    }
    public async Task<TaskDto?> UpdateTaskXPAsync(int id, UpdateTaskXpDto dto)
    {
        if(dto.Experience < 0)
            throw new ArgumentException("Experience points cannot be negative.");
        
        var updatedTask = await _taskRepository.UpdateTaskExperienceAsync(id, dto.Experience);
        return updatedTask?.ToDto();
    }
    public async Task<TaskDto?> UpdateTaskGainsAsync(int id, UpdateTaskGainsDto dto)
    {
        var task = new Models.Task
        {
            VitalityGain = dto.VitalityGain,
            EnduranceGain = dto.EnduranceGain,
            StrengthGain = dto.StrengthGain,
            IntelligenceGain = dto.IntelligenceGain,
            MentalityGain = dto.MentalityGain,
            DexterityGain = dto.DexterityGain
        };

        var updatedTask = await _taskRepository.UpdateTaskGainsAsync(id, task);
        return updatedTask?.ToDto();
    }
}