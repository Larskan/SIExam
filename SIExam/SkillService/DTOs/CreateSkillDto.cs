namespace SkillService.DTOs;

public class CreateSkillDto
{
    public int StatusId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Mastery { get; set; } = string.Empty;
    public int Level { get; set; }
    public int VitalityGain { get; set; }
    public int EnduranceGain { get; set; }
    public int StrengthGain { get; set; }
    public int IntelligenceGain { get; set; }
    public int MentalityGain { get; set; }
    public int DexterityGain { get; set; }
}