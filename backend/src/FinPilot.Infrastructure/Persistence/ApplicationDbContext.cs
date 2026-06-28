using FinPilot.Domain.Common;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinPilot.Infrastructure.Persistence;

/// <summary>
/// Entity Framework Core DbContext for the FinPilot application.
/// Central point for all database interactions.
/// Handles audit field population and soft-delete query filters.
/// Entity configurations are auto-discovered from the Configurations folder.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // ── Identity DbSets ──────────────────────────────────────

    /// <summary>Application users.</summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>Security roles.</summary>
    public DbSet<Role> Roles => Set<Role>();

    /// <summary>Granular permissions.</summary>
    public DbSet<Permission> Permissions => Set<Permission>();

    /// <summary>User-to-role assignments.</summary>
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    /// <summary>Role-to-permission assignments.</summary>
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    /// <summary>Hashed refresh tokens.</summary>
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    /// <summary>Email verification tokens.</summary>
    public DbSet<EmailVerificationToken> EmailVerificationTokens => Set<EmailVerificationToken>();

    /// <summary>Password reset tokens.</summary>
    public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();

    /// <summary>Login audit trail.</summary>
    public DbSet<LoginHistory> LoginHistory => Set<LoginHistory>();

    /// <summary>Active user sessions.</summary>
    public DbSet<UserSession> UserSessions => Set<UserSession>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all entity configurations from this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    /// <summary>
    /// Override SaveChangesAsync to automatically populate audit fields
    /// on entities inheriting from <see cref="BaseAuditableEntity"/>.
    /// </summary>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = utcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = utcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
