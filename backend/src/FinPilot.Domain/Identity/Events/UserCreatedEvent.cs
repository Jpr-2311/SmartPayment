using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity.Events;

/// <summary>
/// Raised when a new user account is created.
/// Handlers (Phase 2.2+) may send welcome emails, initialize wallets, etc.
/// </summary>
public sealed record UserCreatedEvent(Guid UserId, string Email, string Username) : DomainEvent;
