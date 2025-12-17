namespace TaskService.DTOs;

public class TaskDto
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Experience { get; set; }
    public int VitalityGain { get; set; }
    public int EnduranceGain { get; set; }
    public int StrengthGain { get; set; }
    public int IntelligenceGain { get; set; }
    public int MentalityGain { get; set; }
    public int DexterityGain { get; set; }
}