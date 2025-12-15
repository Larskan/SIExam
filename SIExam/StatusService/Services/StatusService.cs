using StatusService.Interfaces;
using StatusService.Models;

namespace StatusService.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;

    public StatusService(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }

    public async Task<Status?> GetStatusByIdAsync(int id)
        => await _statusRepository.GetStatusByIdAsync(id);

    public async Task<Status> CreateStatusAsync(Status status)
        => await _statusRepository.CreateStatusAsync(status);

    public async Task RegisterExperienceAsync(int statusId, int xpGained)
    {
        var status = await _statusRepository.GetStatusByIdAsync(statusId) ?? throw new Exception("Status not found");
        status.Experience += xpGained;

        if(status.Experience >= status.Level * 100)
        {
            status.Level++;
            status.Experience = 0;
        }
        await _statusRepository.UpdateStatusAsync(statusId, status);
    }

    public async Task RegisterStatsAsync(int statusId, int vitality, int endurance, int strength, int intelligence, int mentality, int dexterity)
    {
        var existingStatus = await _statusRepository.GetStatusByIdAsync(statusId) ?? throw new Exception("Status not found");
        if (existingStatus != null)
        {
            existingStatus.Vitality += vitality;
            existingStatus.Endurance += endurance;
            existingStatus.Strength += strength;
            existingStatus.Intelligence += intelligence;
            existingStatus.Mentality += mentality;
            existingStatus.Dexterity += dexterity;

            await _statusRepository.UpdateStatusAsync(statusId, existingStatus);
        }
    }
}