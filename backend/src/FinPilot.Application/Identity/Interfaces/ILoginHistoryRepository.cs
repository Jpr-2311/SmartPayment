using FinPilot.Application.Common.Interfaces;
using FinPilot.Domain.Identity;

namespace FinPilot.Application.Identity.Interfaces;

/// <summary>
/// Repository interface for <see cref="LoginHistory"/> entities.
/// Extends the generic repository with login-history-specific queries.
/// </summary>
public interface ILoginHistoryRepository : IRepository<LoginHistory>
{
    /// <summary>Gets paginated login history for a user, ordered by most recent first.</summary>
    Task<IReadOnlyList<LoginHistory>> GetByUserIdAsync(Guid userId, int page = 1, int pageSize = 20, CancellationToken cancellationToken = default);

    /// <summary>Gets recent failed login attempts for a user within a time window.</summary>
    Task<int> GetRecentFailedAttemptsCountAsync(Guid userId, TimeSpan window, CancellationToken cancellationToken = default);
}
