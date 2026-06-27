using MediatR;

namespace FinPilot.Domain.Common;

/// <summary>
/// Marker interface for domain events.
/// Domain events are raised by entities and handled by event handlers.
/// Uses MediatR INotification for publish/subscribe pattern.
/// </summary>
public interface IDomainEvent : INotification
{
    DateTime OccurredAt { get; }
}

/// <summary>
/// Base implementation of a domain event with timestamp.
/// </summary>
public abstract record DomainEvent : IDomainEvent
{
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
}
