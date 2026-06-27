using Asp.Versioning;
using FinPilot.Shared.Constants;

namespace FinPilot.API.Extensions;

/// <summary>
/// Extension methods for registering API-level services.
/// Keeps Program.cs clean and focused.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers API-specific services: CORS, Swagger, API Versioning, Health Checks.
    /// </summary>
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // CORS
        services.AddCors(options =>
        {
            options.AddPolicy(AppConstants.Cors.AllowFrontend, policy =>
            {
                policy
                    .WithOrigins(configuration.GetValue<string>("FrontendUrl") ?? "http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        // API Versioning
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-API-Version"));
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        // Swagger / OpenAPI
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new()
            {
                Title = $"{AppConstants.AppName} API",
                Version = "v1",
                Description = "AI-Powered Personal Finance & Smart Payment Platform API"
            });

            // Include XML comments for documentation
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        });

        // Health Checks
        services.AddHealthChecks()
            .AddNpgSql(
                configuration.GetConnectionString("DefaultConnection") ?? "",
                name: "postgresql",
                tags: ["database", "ready"]);

        return services;
    }
}
