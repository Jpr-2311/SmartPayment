using Microsoft.EntityFrameworkCore;

namespace FinPilot.Infrastructure.Persistence;

/// <summary>
/// Entity Framework Core DbContext for the FinPilot application.
/// This is the central point for database interaction.
/// Entity configurations are applied from the Configurations folder.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets will be added in future phases as entities are created
    // Example: public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all entity configurations from this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    /// <summary>
    /// Override SaveChangesAsync to automatically set audit fields.
    /// </summary>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Future: Automatically set CreatedAt, UpdatedAt, CreatedBy, UpdatedBy
        // on BaseAuditableEntity instances
        return await base.SaveChangesAsync(cancellationToken);
    }
}
