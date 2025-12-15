using Microsoft.EntityFrameworkCore;
using Polly;
using StatusService.Interfaces;
using StatusService.Models;
using StatusService.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StatusService.Data.StatusDbContext>(options =>
    options.UseSqlServer("DefaultConnection"));

builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService.Services.StatusService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.UseHttpsRedirection();


app.Run();

