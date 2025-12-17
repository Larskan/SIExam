using TitleService.Models;

namespace TitleService.Interfaces;

public interface ITitleRepository
{
    Task<List<Titles>?> GetAllTitlesAsync();
    Task<Titles> CreateTitleAsync(Titles title);
    Task<Titles?> UpdateTitleNameAsync(int id, string name);
    Task<Titles?> UpdateTitleDescriptionAsync(int id, string description);
    Task<Titles?> UpdateTitleGainsAsync(int id, Titles title);
    Task<Titles?> UpdateTitleTierAsync(int id, int tier);
}