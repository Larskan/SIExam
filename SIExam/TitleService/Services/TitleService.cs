using TitleService.Data;
using TitleService.Interfaces;
using TitleService.DTOs;
using TitleService.Models;

namespace TitleService.Services;

public class TitleService : ITitleService
{
    private readonly ITitleRepository _titleRepository;
    public TitleService(ITitleRepository titleRepository)
    {
        _titleRepository = titleRepository;
    }

    public async Task<List<TitleDto>?> GetAllTitlesAsync()
    {
        var titles = await _titleRepository.GetAllTitlesAsync();

        if (titles is null || titles.Count == 0)
            return null;

        return titles.Select(t => t.ToDto()).ToList();
    }

    public async Task<TitleDto> CreateTitleAsync(CreateTitleDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Title name cannot be empty.");
        
        if(string.IsNullOrWhiteSpace(dto.Description))
            throw new ArgumentException("Title description cannot be empty.");
        
        var title = new Titles
        {
            StatusId = dto.StatusId,
            Title = dto.Title,
            Tier = dto.Tier,
            Requirements = dto.Requirements,
            Description = dto.Description,
            TierAdvancementRequirements = dto.TierAdvancementRequirements,
            VitalityGain = dto.VitalityGain,
            EnduranceGain = dto.EnduranceGain,
            StrengthGain = dto.StrengthGain,
            IntelligenceGain = dto.IntelligenceGain,
            MentalityGain = dto.MentalityGain,
            DexterityGain = dto.DexterityGain
        };

        var createdTitle = await _titleRepository.CreateTitleAsync(title);
        return createdTitle.ToDto();
    }

    public async Task<TitleDto?> UpdateTitleNameAsync(int id, UpdateTitleNameDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Title name cannot be empty.");
        
        var updatedTitle = await _titleRepository.UpdateTitleNameAsync(id, dto.Title);
        return updatedTitle?.ToDto();
    }
    public async Task<TitleDto?> UpdateTitleDescriptionAsync(int id, UpdateTitleDescriptionDto dto)
    {
        if(string.IsNullOrWhiteSpace(dto.Description))
            throw new ArgumentException("Title description cannot be empty.");
        
        var updatedTitle = await _titleRepository.UpdateTitleDescriptionAsync(id, dto.Description);
        return updatedTitle?.ToDto();
    }
    public async Task<TitleDto?> UpdateTitleGainsAsync(int id, UpdateTitleGainsDto dto)
    {
        var title = new Titles
        {
            VitalityGain = dto.VitalityGain,
            EnduranceGain = dto.EnduranceGain,
            StrengthGain = dto.StrengthGain,
            IntelligenceGain = dto.IntelligenceGain,
            MentalityGain = dto.MentalityGain,
            DexterityGain = dto.DexterityGain
        };

        var updatedTitle = await _titleRepository.UpdateTitleGainsAsync(id, title);
        return updatedTitle?.ToDto();
    }
    public async Task<TitleDto?> UpdateTitleTierAsync(int id, UpdateTitleTierDto dto)
    {
        if(dto.Tier < 0)
            throw new ArgumentException("Title tier cannot be negative.");
        
        var updatedTitle = await _titleRepository.UpdateTitleTierAsync(id, dto.Tier);
        return updatedTitle?.ToDto();
    }
}