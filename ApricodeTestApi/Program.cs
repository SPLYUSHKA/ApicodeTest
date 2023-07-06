using ApricodeTestApi.Core.Entities;
using ApricodeTestApi.Core.Repositories;
using AprocodeTestApi.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Services

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GamesContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("local")));

builder.Services.AddTransient<IRepository<Genre>, GenresRepository>();
builder.Services.AddTransient<IRepository<Developer>, DeveloperRepository>();
builder.Services.AddTransient<IGamesRepository, GamesRepository>();



var app = builder.Build();


// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
