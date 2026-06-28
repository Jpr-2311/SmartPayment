using FinPilot.Application.Identity.Interfaces;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinPilot.Infrastructure.Persistence.Repositories;

/// <summary>
/// EF Core implementation of <see cref="IPermissionRepository"/>.
/// </summary>
public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionRepository"/> class.
    /// </summary>
    public PermissionRepository(ApplicationDbContext context) : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Permission>> GetByModuleAsync(
        string module,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(p => p.Module == module)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Permission>> GetByNamesAsync(
        IEnumerable<string> names,
        CancellationToken cancellationToken = default)
    {
        var nameList = names.ToList();
        return await DbSet
            .Where(p => nameList.Contains(p.Name))
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<string>> GetPermissionNamesByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<UserRole>()
            .Where(ur => ur.UserId == userId)
            .SelectMany(ur => ur.Role.RolePermissions)
            .Select(rp => rp.Permission.Name)
            .Distinct()
            .ToListAsync(cancellationToken);
    }
}
