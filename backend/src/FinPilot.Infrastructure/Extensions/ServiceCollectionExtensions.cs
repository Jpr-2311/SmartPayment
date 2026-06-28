using FinPilot.Application.Common.Interfaces;
using FinPilot.Application.Identity.Interfaces;
using FinPilot.Infrastructure.Persistence;
using FinPilot.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinPilot.Infrastructure.Extensions;

/// <summary>
/// Extension methods for registering Infrastructure layer services.
/// Called from the API project's Program.cs.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ── PostgreSQL + Entity Framework Core ───────────────
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorCodesToAdd: null);
                });
        });

        // ── Unit of Work ─────────────────────────────────────
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // ── Generic Repository ───────────────────────────────
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        // ── Identity Repositories ────────────────────────────
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<ILoginHistoryRepository, LoginHistoryRepository>();
        services.AddScoped<IUserSessionRepository, UserSessionRepository>();

        return services;
    }
}
