using FinPilot.Application.Identity.Interfaces;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinPilot.Infrastructure.Persistence.Repositories;

/// <summary>
/// EF Core implementation of <see cref="ILoginHistoryRepository"/>.
/// </summary>
public class LoginHistoryRepository : BaseRepository<LoginHistory>, ILoginHistoryRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginHistoryRepository"/> class.
    /// </summary>
    public LoginHistoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<LoginHistory>> GetByUserIdAsync(
        Guid userId,
        int page = 1,
        int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(h => h.UserId == userId)
            .OrderByDescending(h => h.LoginTime)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> GetRecentFailedAttemptsCountAsync(
        Guid userId,
        TimeSpan window,
        CancellationToken cancellationToken = default)
    {
        var cutoff = DateTime.UtcNow - window;
        return await DbSet
            .CountAsync(h =>
                h.UserId == userId &&
                !h.IsSuccessful &&
                h.LoginTime >= cutoff,
                cancellationToken);
    }
}
