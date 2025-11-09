using GeographyAPI.Data;
using GeographyAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddControllers();
builder.Services.AddDbContext<GeographyContext>(options =>
    options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddScoped<ICountryRepo, MockCountryRepo>();
builder.Services.AddScoped<ICountryLanguageRepo, MockCountryLanguageRepo>();
builder.Services.AddScoped<ILanguageRepo, MockLanguageRepo>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
