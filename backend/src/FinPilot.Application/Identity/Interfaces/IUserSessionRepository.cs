using FinPilot.Application.Common.Interfaces;
using FinPilot.Domain.Identity;

namespace FinPilot.Application.Identity.Interfaces;

/// <summary>
/// Repository interface for <see cref="UserSession"/> entities.
/// Extends the generic repository with session management methods.
/// </summary>
public interface IUserSessionRepository : IRepository<UserSession>
{
    /// <summary>Gets all active sessions for a user.</summary>
    Task<IReadOnlyList<UserSession>> GetActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Deactivates all sessions for a user (e.g., "logout everywhere").</summary>
    Task DeactivateAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Finds a session by its unique token.</summary>
    Task<UserSession?> GetBySessionTokenAsync(string sessionToken, CancellationToken cancellationToken = default);
}
