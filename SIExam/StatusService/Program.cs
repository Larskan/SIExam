using Microsoft.EntityFrameworkCore;
using Polly;
using StatusService.Interfaces;
using StatusService.Models;
using StatusService.Repositories;
using StatusService.Resilience;


var builder = WebApplication.CreateBuilder(args);

// Resilience for SkillService.
builder.Services.AddHttpClient("SkillService", client =>
{
    client.BaseAddress = new Uri("http://skillservice:8080");
})
.AddPolicyHandler(PollyPolicies.TimeoutPolicy)
.AddPolicyHandler(PollyPolicies.RetryPolicy)
.AddPolicyHandler(PollyPolicies.CircuitBreakerPolicy);

// Resilience for TaskService
builder.Services.AddHttpClient("TaskService", client =>
{
    client.BaseAddress = new Uri("http://taskservice:8080");
})
.AddPolicyHandler(PollyPolicies.TimeoutPolicy)
.AddPolicyHandler(PollyPolicies.RetryPolicy)
.AddPolicyHandler(PollyPolicies.CircuitBreakerPolicy);

// Resilience for TitleService
builder.Services.AddHttpClient("TitleService", client =>
{
    client.BaseAddress = new Uri("http://titleservice:8080");
})
.AddPolicyHandler(PollyPolicies.TimeoutPolicy)
.AddPolicyHandler(PollyPolicies.RetryPolicy)
.AddPolicyHandler(PollyPolicies.CircuitBreakerPolicy);



builder.Services.AddDbContext<StatusService.Data.StatusDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService.Services.StatusService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();


app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();

