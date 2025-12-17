using Microsoft.EntityFrameworkCore;
using TitleService.Data;
using TitleService.Interfaces;
using TitleService.Models;


public class TitleRepository : ITitleRepository
{
    private readonly TitleDbContext _context;

    public TitleRepository(TitleDbContext context)
    {
        _context = context;
    }

    public async Task<List<Titles>?> GetAllTitlesAsync()
    {
        return await _context.Titles.ToListAsync();
    }

    public async Task<Titles> CreateTitleAsync(Titles titles)
    {
        _context.Titles.Add(titles);
        await _context.SaveChangesAsync();
        return titles;
    }

    public async Task<Titles?> UpdateTitleNameAsync(int id, string name)
    {
        var existingTitle = await _context.Titles.FindAsync(id);
        if (existingTitle == null)
            return null;

        existingTitle.Title = name;
        await _context.SaveChangesAsync();
        return existingTitle;
    }
    public async Task<Titles?> UpdateTitleDescriptionAsync(int id, string description)
    {
        var existingTitle = await _context.Titles.FindAsync(id);
        if (existingTitle == null)
            return null;

        existingTitle.Requirements = description;
        await _context.SaveChangesAsync();
        return existingTitle;
    }
    public async Task<Titles?> UpdateTitleGainsAsync(int id, Titles titles)
    {
        var existingTitle = await _context.Titles.FindAsync(id);
        if (existingTitle == null)
            return null;

        existingTitle.Tier = titles.Tier;
        await _context.SaveChangesAsync();
        return existingTitle;
    }
    public async Task<Titles?> UpdateTitleTierAsync(int id, int tier)
    {
        var existingTitle = await _context.Titles.FindAsync(id);
        if (existingTitle == null)
            return null;

        existingTitle.Tier = tier;
        await _context.SaveChangesAsync();
        return existingTitle;
    }
}