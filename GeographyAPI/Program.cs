using GeographyAPI.Data;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddControllers();
builder.Services.AddDbContext<GeographyContext>(options =>
    options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<ICountryLanguageRepo, CountryLanguageRepo>();
builder.Services.AddScoped<ILanguageRepo, LanguageRepo>();

//Adding Rate Limiting
builder.Services.AddRateLimiter(options =>
{
    // Return a 429 Too Many Requests status code when a limit is breached
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddFixedWindowLimiter(policyName: "Fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 3;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 0;
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.MapControllers().RequireRateLimiting("Fixed");

app.Run();
