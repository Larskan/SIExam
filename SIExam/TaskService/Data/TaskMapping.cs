using TaskService.DTOs;

namespace TaskService.Data;

public static class TaskMappings
{
    public static TaskDto ToDto(this Models.Task task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Description = task.Description,
            Experience = task.Experience,
            VitalityGain = task.VitalityGain,
            EnduranceGain = task.EnduranceGain,
            StrengthGain = task.StrengthGain,
            IntelligenceGain = task.IntelligenceGain,
            MentalityGain = task.MentalityGain,
            DexterityGain = task.DexterityGain
        };
    }
}