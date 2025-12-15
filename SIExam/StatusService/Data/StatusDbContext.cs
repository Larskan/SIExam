namespace StatusService.Data;

using Microsoft.EntityFrameworkCore;
using StatusService.Models;

public class StatusDbContext : DbContext
{
    public StatusDbContext(DbContextOptions<StatusDbContext> options) : base(options)
    {
    }

    public DbSet<Status> Statuses { get; set; }
}