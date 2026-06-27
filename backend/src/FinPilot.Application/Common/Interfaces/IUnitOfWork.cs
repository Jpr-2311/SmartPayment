namespace FinPilot.Application.Common.Interfaces;

/// <summary>
/// Unit of Work interface for coordinating multiple repository operations
/// within a single database transaction.
/// Concrete implementation will be in the Infrastructure layer.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Commits all changes made through repositories in a single transaction.
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
