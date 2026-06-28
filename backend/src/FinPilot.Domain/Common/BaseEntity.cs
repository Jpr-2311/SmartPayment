using FinPilot.Domain.Common;

namespace FinPilot.Domain.Common;

/// <summary>
/// Base entity with an Id, creation timestamp, and domain events collection.
/// All domain entities inherit from this.
/// Domain events are collected and dispatched after persistence via MediatR.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Primary key. Generated as a new GUID by default.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// UTC timestamp when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Domain events raised by this entity, dispatched after SaveChanges.
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Read-only view of pending domain events.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adds a domain event to be dispatched after persistence.
    /// </summary>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clears all pending domain events. Called after dispatch.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
