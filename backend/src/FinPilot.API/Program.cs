using Serilog;
using FinPilot.API.Extensions;
using FinPilot.API.Middleware;
using FinPilot.Infrastructure.Extensions;
using FinPilot.Infrastructure.Logging;
using FinPilot.Shared.Constants;

// Configure Serilog early to catch startup errors
SerilogConfiguration.ConfigureLogging();

try
{
    Log.Information("Starting {AppName} v{Version}", AppConstants.AppName, AppConstants.AppVersion);

    var builder = WebApplication.CreateBuilder(args);

    // Serilog integration
    builder.Host.UseSerilog();

    // Controllers
    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });

    // API services (CORS, Swagger, Versioning, Health Checks)
    builder.Services.AddApiServices(builder.Configuration);

    // Infrastructure services (EF Core, Repositories)
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();

    // Global exception handling
    app.UseGlobalExceptionHandling();

    // Serilog request logging
    app.UseSerilogRequestLogging();

    // Swagger (all environments for now; restrict in production later)
    if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "FinPilot AI API v1");
            options.RoutePrefix = "swagger";
        });
    }

    // CORS
    app.UseCors(AppConstants.Cors.AllowFrontend);

    // HTTPS redirection (disabled in development for Docker compatibility)
    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    // Authorization (will be configured in Phase 2)
    app.UseAuthorization();

    // Map controllers
    app.MapControllers();

    // Health check endpoint
    app.MapHealthChecks("/health");

    // Startup log
    Log.Information("{AppName} started successfully on {Urls}",
        AppConstants.AppName,
        string.Join(", ", app.Urls));

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
