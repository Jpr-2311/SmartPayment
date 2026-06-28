using FinPilot.Application.Common.Interfaces;
using FinPilot.Domain.Identity;

namespace FinPilot.Application.Identity.Interfaces;

/// <summary>
/// Repository interface for <see cref="Role"/> entities.
/// Extends the generic repository with role-specific query methods.
/// </summary>
public interface IRoleRepository : IRepository<Role>
{
    /// <summary>Finds a role by its unique name.</summary>
    Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>Finds a role by Id, eagerly loading its permissions.</summary>
    Task<Role?> GetWithPermissionsAsync(Guid roleId, CancellationToken cancellationToken = default);
}
