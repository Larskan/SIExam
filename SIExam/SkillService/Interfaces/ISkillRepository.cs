using Microsoft.EntityFrameworkCore;
using SkillService.Data;
using SkillService.Interfaces;
using SkillService.Models;

namespace SkillService.Interfaces;

public interface ISkillRepository
{
    Task<List<Skill>?> GetAllSkillsAsync();
    Task<Skill?> UpdateMasteryAsync(int id, Skill skill);
    Task<Skill> CreateSkillAsync(Skill skill);
    Task<Skill?> UpdateLevelAsync(int id, Skill skill);
}