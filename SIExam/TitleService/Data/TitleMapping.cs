
using TitleService.DTOs;
using TitleService.Models;

namespace TitleService.Data;


public static class TitleMapping
{
    public static TitleDto ToDto(this Titles title)
    {
        return new TitleDto
        {
            Id = title.Id,
            StatusId = title.StatusId,
            Title = title.Title,
            Tier = title.Tier,
            Requirements = title.Requirements,
            Description = title.Description,
            TierAdvancementRequirements = title.TierAdvancementRequirements,
            VitalityGain = title.VitalityGain,
            EnduranceGain = title.EnduranceGain,
            StrengthGain = title.StrengthGain,
            IntelligenceGain = title.IntelligenceGain,
            MentalityGain = title.MentalityGain,
            DexterityGain = title.DexterityGain
        };
    }
}