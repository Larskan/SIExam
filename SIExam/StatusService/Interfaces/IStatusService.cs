using StatusService.Models;

namespace StatusService.Interfaces
{
    public interface IStatusService
    {
        Task<Status?> GetStatusByIdAsync(int id);
        Task<Status> CreateStatusAsync(Status status);
        Task RegisterExperienceAsync(int statusId, int xpGained);
        Task RegisterStatsAsync(int statusId, int vitality, int endurance, int strength, int intelligence, int mentality, int dexterity);
    }
}