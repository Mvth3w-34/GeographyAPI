var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInjectedServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers().RequireRateLimiting("Fixed");

app.Run();
