using FinPilot.Application.Common.Interfaces;
using FinPilot.Domain.Identity;

namespace FinPilot.Application.Identity.Interfaces;

/// <summary>
/// Repository interface for <see cref="RefreshToken"/> entities.
/// Extends the generic repository with token-specific query methods.
/// </summary>
public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    /// <summary>Finds a refresh token by its hash.</summary>
    Task<RefreshToken?> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken = default);

    /// <summary>Gets all active (non-revoked, non-expired) tokens for a user.</summary>
    Task<IReadOnlyList<RefreshToken>> GetActiveByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    /// <summary>Revokes all refresh tokens for a user (e.g., on password change).</summary>
    Task RevokeAllByUserIdAsync(Guid userId, string reason, CancellationToken cancellationToken = default);
}
