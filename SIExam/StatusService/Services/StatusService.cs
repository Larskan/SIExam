using Polly.Timeout;
using StatusService.Interfaces;
using StatusService.Models;

namespace StatusService.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;
    private readonly HttpClient _skillClient;
    private readonly ILogger<StatusService> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<StatusService>();

    public StatusService(IStatusRepository statusRepository, IHttpClientFactory httpClientFactory)
    {
        _statusRepository = statusRepository;
        _skillClient = httpClientFactory.CreateClient("SkillService");
    }

    // For resilience testing
    public async Task<string> CallSkillServiceSlowEndpointAsync()
    {
        try
        {
            var response = await _skillClient.GetAsync("/api/Skill/slow");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (TimeoutRejectedException ex)
        {
            _logger.LogWarning(ex, "SkillService call timed out.");
            return "SkillService request timed out.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while calling SkillService.");
            return "An error occurred while calling SkillService.";
        }
    }

    public async Task<string> CallSkillServiceUnreliableEndpointAsync()
    {
        try
        {
            var response = await _skillClient.GetAsync("/api/Skill/unreliable");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while calling SkillService.");
            return "An error occurred while calling SkillService.";
        }
    }

    public async Task<string> CallSkillServiceUnstableEndpointAsync()
    {
        try
        {
            var response = await _skillClient.GetAsync("/api/Skill/unstable");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while calling SkillService.");
            return "An error occurred while calling SkillService.";
        }
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