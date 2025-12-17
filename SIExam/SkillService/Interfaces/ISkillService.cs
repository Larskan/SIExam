using SkillService.DTOs;

namespace SkillService.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
    Task<SkillDto> CreateSkillAsync(CreateSkillDto dto);
    Task<SkillDto?> UpdateSkillWithMasteryAsync(int id, UpdateSkillMasteryDto dto);
    Task<SkillDto?> UpdateSkillWithLevelAsync(int id, UpdateSkillLevelDto dto);
}