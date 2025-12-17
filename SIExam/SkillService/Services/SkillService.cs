using SkillService.Data;
using SkillService.Interfaces;
using SkillService.DTOs;
using SkillService.Models;

namespace SkillService.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;
    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
    {
        var skills = await _skillRepository.GetAllSkillsAsync();

        if (skills is null || skills.Count == 0)
            return Enumerable.Empty<SkillDto>();

        return skills.Select(s => s.ToDto());
    }

    public async Task<SkillDto> CreateSkillAsync(CreateSkillDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Skill name cannot be empty.");
        
        var skill = new Skill
        {
            StatusId = dto.StatusId,
            Name = dto.Name,
            Mastery = dto.Mastery,
            Level = dto.Level,
            VitalityGain = dto.VitalityGain,
            EnduranceGain = dto.EnduranceGain,
            StrengthGain = dto.StrengthGain,
            IntelligenceGain = dto.IntelligenceGain,
            MentalityGain = dto.MentalityGain,
            DexterityGain = dto.DexterityGain
        };

        var createdSkill = await _skillRepository.CreateSkillAsync(skill);
        return createdSkill.ToDto();
    }

    public async Task<SkillDto?> UpdateSkillWithMasteryAsync(int id, UpdateSkillMasteryDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Mastery))
            throw new ArgumentException("Mastery cannot be empty.");
        
        var skill = new Skill
        {
            Mastery = dto.Mastery
        };

        var updatedSkill = await _skillRepository.UpdateMasteryAsync(id, skill);
        return updatedSkill?.ToDto();
    }

    public async Task<SkillDto?> UpdateSkillWithLevelAsync(int id, UpdateSkillLevelDto dto)
    {
        if(dto.Level < 0)
            throw new ArgumentException("Level must be at least 0.");
        
        var skill = new Skill
        {
            Level = dto.Level
        };

        var updatedSkill = await _skillRepository.UpdateLevelAsync(id, skill);
        return updatedSkill?.ToDto();
    }
}