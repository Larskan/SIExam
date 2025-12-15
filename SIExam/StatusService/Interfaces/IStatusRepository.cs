using StatusService.Models;

namespace StatusService.Interfaces;

public interface IStatusRepository
{
    Task<Status?> GetStatusByIdAsync(int id);
    Task<IEnumerable<Status>> GetAllStatusesAsync();
    Task<Status> CreateStatusAsync(Status status);
    Task<Status?> UpdateStatusAsync(int id, Status status);
}