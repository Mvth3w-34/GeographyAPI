using GeographyAPI.Authentication;
using GeographyAPI.Data;
using GeographyAPI.Repositories;
using GeographyAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
        services.AddScoped<ILanguageRepo, LanguageRepo>();
        services.AddScoped<IJwtGenerator, JwtGenerator>();
        services.AddScoped<IJwtManagerService, JwtManagerService>();

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

        // JWT bearer authentication

        var jwtSecret = configuration["Jwt:Secret"];
        var key = Encoding.UTF8.GetBytes(jwtSecret);
        var securityKey = new SymmetricSecurityKey(key);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtOptions =>
        {
            jwtOptions.RequireHttpsMetadata = false;
            jwtOptions.TokenValidationParameters = new TokenValidationParameters
            {

                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,

                IssuerSigningKey = securityKey,
                ValidAudience = configuration["Jwt:Audience"],
                ValidIssuer = configuration["Jwt:Issuer"],

                ClockSkew = TimeSpan.Zero
            };

        });

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
    }
}