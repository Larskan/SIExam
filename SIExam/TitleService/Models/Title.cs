namespace TitleService.Models;

public class Titles
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Tier { get; set; }
    public string? Requirements { get; set; }
    public required string Description { get; set; }
    public required string TierAdvancementRequirements { get; set; }
    public int VitalityGain { get; set; }
    public int EnduranceGain { get; set; }
    public int StrengthGain { get; set; }
    public int IntelligenceGain { get; set; }
    public int MentalityGain { get; set; }
    public int DexterityGain { get; set; }
}
