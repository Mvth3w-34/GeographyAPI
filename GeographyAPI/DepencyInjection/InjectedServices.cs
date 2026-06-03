using GeographyAPI.Data;
using GeographyAPI.Repositories;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

public static class InjectedServices
{
    public static void AddInjectedServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionString"];

        services.AddControllers();
        services.AddDbContext<GeographyContext>(options =>
            options.UseSqlServer(connectionString ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
        services.AddScoped<ICountryRepo, CountryRepo>();
        services.AddScoped<ICountryLanguageRepo, CountryLanguageRepo>();
        services.AddScoped<ILanguageRepo, LanguageRepo>();

        //Adding Rate Limiting
        services.AddRateLimiter(options =>
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
        services.AddOpenApi();
    }
}