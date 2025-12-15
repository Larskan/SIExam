namespace TaskService.Models;

public class Task
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required int Experience { get; set; }
    public int VitalityGain { get; set; }
    public int EnduranceGain { get; set; }
    public int StrengthGain { get; set; }
    public int IntelligenceGain { get; set; }
    public int MentalityGain { get; set; }
    public int DexterityGain { get; set; }

}
