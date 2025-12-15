namespace SkillService.Models;

public class Skill
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Mastery { get; set; }
    public int VitalityGain { get; set; }
    public int EnduranceGain { get; set; }
    public int StrengthGain { get; set; }
    public int IntelligenceGain { get; set; }
    public int MentalityGain { get; set; }
    public int DexterityGain { get; set; }
}
