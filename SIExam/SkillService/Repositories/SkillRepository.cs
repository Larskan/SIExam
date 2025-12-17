using Microsoft.EntityFrameworkCore;
using SkillService.Data;
using SkillService.Interfaces;
using SkillService.Models;

namespace SkillService.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly SkillDbContext _context;

    public SkillRepository(SkillDbContext context)
    {
        _context = context;
    }

    public async Task<List<Skill>?> GetAllSkillsAsync()
        => await _context.Skills.ToListAsync();

    public async Task<Skill> CreateSkillAsync(Skill skill)
    {
        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<Skill?> UpdateSkillWithMasteryAsync(int id, Skill skill)
    {
        var existingSkill = await _context.Skills.FindAsync(id);
        if (existingSkill == null)
            return null;
        existingSkill.Mastery = skill.Mastery;

        await _context.SaveChangesAsync();
        return existingSkill;
    }

    public async Task<Skill?> UpdateSkillWithLevelAsync(int id, Skill skill)
    {
        var existingSkill = await _context.Skills.FindAsync(id);
        if (existingSkill == null)
            return null;
        existingSkill.Level = skill.Level;
        await _context.SaveChangesAsync();
        return existingSkill;
    }
}