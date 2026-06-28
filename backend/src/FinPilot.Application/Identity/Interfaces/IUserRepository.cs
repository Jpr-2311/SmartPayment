using FinPilot.Application.Common.Interfaces;
using FinPilot.Domain.Identity;

namespace FinPilot.Application.Identity.Interfaces;

/// <summary>
/// Repository interface for <see cref="User"/> entities.
/// Extends the generic repository with identity-specific query methods.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>Finds a user by their unique email address.</summary>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>Finds a user by their unique username.</summary>
    Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);

    /// <summary>Finds a user by Id, eagerly loading their roles and permissions.</summary>
    Task<User?> GetWithRolesAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Checks whether a user with the given email already exists.</summary>
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>Checks whether a user with the given username already exists.</summary>
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
}
