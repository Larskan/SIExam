
using TitleService.DTOs;
namespace TitleService.Interfaces;

public interface ITitleService
{
    Task<List<TitleDto>?> GetAllTitlesAsync();
    Task<TitleDto> CreateTitleAsync(CreateTitleDto title);
    Task<TitleDto?> UpdateTitleNameAsync(int id, UpdateTitleNameDto dto);
    Task<TitleDto?> UpdateTitleDescriptionAsync(int id, UpdateTitleDescriptionDto dto);
    Task<TitleDto?> UpdateTitleGainsAsync(int id, UpdateTitleGainsDto dto);
    Task<TitleDto?> UpdateTitleTierAsync(int id, UpdateTitleTierDto dto);
}