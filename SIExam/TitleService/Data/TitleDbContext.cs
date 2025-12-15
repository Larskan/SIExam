namespace TitleService.Data;

using Microsoft.EntityFrameworkCore;
using TitleService.Models;

public class TitleDbContext : DbContext
{
    public TitleDbContext(DbContextOptions<TitleDbContext> options) : base(options)
    {
    }

    public DbSet<Titles> Titles { get; set; }
}