using SkillService.DTOs;
using SkillService.Models;

namespace SkillService.Data;

public static class SkillMappings
{
    public static SkillDto ToDto(this Skill skill)
    {
        return new SkillDto
        {
            Id = skill.Id,
            StatusId = skill.StatusId,
            Name = skill.Name,
            Mastery = skill.Mastery,
            Level = skill.Level,
            VitalityGain = skill.VitalityGain,
            EnduranceGain = skill.EnduranceGain,
            StrengthGain = skill.StrengthGain,
            IntelligenceGain = skill.IntelligenceGain,
            MentalityGain = skill.MentalityGain,
            DexterityGain = skill.DexterityGain
        };
    }
}