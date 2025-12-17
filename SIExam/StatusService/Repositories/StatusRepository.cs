using Microsoft.EntityFrameworkCore;
using StatusService.Data;
using StatusService.Interfaces;
using StatusService.Models;

namespace StatusService.Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly StatusDbContext _context;

    public StatusRepository(StatusDbContext context)
    {
        _context = context;
    }

    public async Task<Status?> GetStatusByIdAsync(int id)
        => await _context.Statuses.FindAsync(id);

    public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        => await _context.Statuses.ToListAsync();

    public async Task<Status> CreateStatusAsync(Status status)
    {
        _context.Statuses.Add(status);
        await _context.SaveChangesAsync();
        return status;
    }

    public async Task<Status?> UpdateStatusAsync(int id, Status status)
    {
        var existingStatus = await _context.Statuses.FindAsync(id);
        if (existingStatus == null)
        {
            return null;
        }
        existingStatus.Endurance = status.Endurance;
        existingStatus.Strength = status.Strength;
        existingStatus.Intelligence = status.Intelligence;
        existingStatus.Dexterity = status.Dexterity;
        existingStatus.Vitality = status.Vitality;
        existingStatus.Mentality = status.Mentality;

        await _context.SaveChangesAsync();
        return existingStatus;
    }
}