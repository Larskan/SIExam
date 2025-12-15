namespace SkillService.Data;

using Microsoft.EntityFrameworkCore;
using SkillService.Models;

public class SkillDbContext : DbContext
{
    public SkillDbContext(DbContextOptions<SkillDbContext> options) : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; }
}