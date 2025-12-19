using Microsoft.EntityFrameworkCore;
using Polly;
using StatusService.Interfaces;
using StatusService.Repositories;
using StatusService.Resilience;


var builder = WebApplication.CreateBuilder(args);

// Resilience for SkillService.
builder.Services.AddHttpClient("SkillService", client =>
{
    client.BaseAddress = new Uri("http://skillservice:8080");
})
.AddPolicyHandler((sp, request) =>
{
    var logger = sp.GetRequiredService<ILogger<Program>>();
    var timeout = PollyPolicies.TimeoutPolicy(logger);
    var retry = PollyPolicies.RetryPolicy(logger);
    var circuitBreaker = PollyPolicies.CircuitBreakerPolicy(logger);
    return Policy.WrapAsync(circuitBreaker, retry, timeout);
});

// Resilience for TaskService
builder.Services.AddHttpClient("TaskService", client =>
{
    client.BaseAddress = new Uri("http://taskservice:8080");
})
.AddPolicyHandler((sp, request) =>
{
    var logger = sp.GetRequiredService<ILogger<Program>>();
    var timeout = PollyPolicies.TimeoutPolicy(logger);
    var retry = PollyPolicies.RetryPolicy(logger);
    var circuitBreaker = PollyPolicies.CircuitBreakerPolicy(logger);
    return Policy.WrapAsync(circuitBreaker, retry, timeout);
});

// Resilience for TitleService
builder.Services.AddHttpClient("TitleService", client =>
{
    client.BaseAddress = new Uri("http://titleservice:8080");
})
.AddPolicyHandler((sp, request) =>
{
    var logger = sp.GetRequiredService<ILogger<Program>>();
    var timeout = PollyPolicies.TimeoutPolicy(logger);
    var retry = PollyPolicies.RetryPolicy(logger);
    var circuitBreaker = PollyPolicies.CircuitBreakerPolicy(logger);
    return Policy.WrapAsync(circuitBreaker, retry, timeout);
});




builder.Services.AddDbContext<StatusService.Data.StatusDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService.Services.StatusService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

app.MapControllers();


app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();

