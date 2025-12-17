namespace TitleService.DTOs;

public class TitleDto
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public string Title { get; set; } = null!;
    public int Tier { get; set; }
    public string? Requirements { get; set; }
    public string Description { get; set; } = null!;
    public string TierAdvancementRequirements { get; set; } = null!;
    public int VitalityGain { get; set; }
    public int EnduranceGain { get; set; }
    public int StrengthGain { get; set; }
    public int IntelligenceGain { get; set; }
    public int MentalityGain { get; set; }
    public int DexterityGain { get; set; }
}