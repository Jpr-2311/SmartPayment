using FinPilot.Application.Common.Interfaces;
using FinPilot.Domain.Identity;

namespace FinPilot.Application.Identity.Interfaces;

/// <summary>
/// Repository interface for <see cref="Permission"/> entities.
/// Extends the generic repository with permission-specific query methods.
/// </summary>
public interface IPermissionRepository : IRepository<Permission>
{
    /// <summary>Gets all permissions for a given module.</summary>
    Task<IReadOnlyList<Permission>> GetByModuleAsync(string module, CancellationToken cancellationToken = default);

    /// <summary>Gets permissions matching any of the given names.</summary>
    Task<IReadOnlyList<Permission>> GetByNamesAsync(IEnumerable<string> names, CancellationToken cancellationToken = default);

    /// <summary>Gets all permissions assigned to a specific user through their roles.</summary>
    Task<IReadOnlyList<string>> GetPermissionNamesByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}
