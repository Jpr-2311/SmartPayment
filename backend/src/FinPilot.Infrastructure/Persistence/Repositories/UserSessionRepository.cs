using FinPilot.Application.Identity.Interfaces;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinPilot.Infrastructure.Persistence.Repositories;

/// <summary>
/// EF Core implementation of <see cref="IUserSessionRepository"/>.
/// </summary>
public class UserSessionRepository : BaseRepository<UserSession>, IUserSessionRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserSessionRepository"/> class.
    /// </summary>
    public UserSessionRepository(ApplicationDbContext context) : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<UserSession>> GetActiveByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(s => s.UserId == userId && s.IsActive && s.ExpiresAt > DateTime.UtcNow)
            .OrderByDescending(s => s.LastActivityAt ?? s.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeactivateAllByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var activeSessions = await DbSet
            .Where(s => s.UserId == userId && s.IsActive)
            .ToListAsync(cancellationToken);

        foreach (var session in activeSessions)
        {
            session.Deactivate();
        }
    }

    /// <inheritdoc />
    public async Task<UserSession?> GetBySessionTokenAsync(
        string sessionToken,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.SessionToken == sessionToken, cancellationToken);
    }
}
