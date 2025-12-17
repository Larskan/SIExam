using Microsoft.EntityFrameworkCore;
using TaskService.Data;
using TaskService.Interfaces;
using Task = TaskService.Models.Task;
using TaskService.DTOs;

namespace TaskService.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<List<Task>?> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task> CreateTaskAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task?> UpdateTaskDescriptionAsync(int id, string description)
    {
        var existingTask = await _context.Tasks.FindAsync(id);
        if (existingTask == null)
            return null;

        existingTask.Description = description;
        await _context.SaveChangesAsync();
        return existingTask;
    }

    public async Task<Task?> UpdateTaskExperienceAsync(int id, int experience)
    {
        var existingTask = await _context.Tasks.FindAsync(id);
        if (existingTask == null)
            return null;

        existingTask.Experience = experience;
        await _context.SaveChangesAsync();
        return existingTask;
    }

    public async Task<Task?> UpdateTaskGainsAsync(int id, Task task)
    {
        var existingTask = await _context.Tasks.FindAsync(id);
        if (existingTask == null)
            return null;

        existingTask.VitalityGain = task.VitalityGain;
        existingTask.EnduranceGain = task.EnduranceGain;
        existingTask.StrengthGain = task.StrengthGain;
        existingTask.IntelligenceGain = task.IntelligenceGain;
        existingTask.MentalityGain = task.MentalityGain;
        existingTask.DexterityGain = task.DexterityGain;

        await _context.SaveChangesAsync();
        return existingTask;
    }
}