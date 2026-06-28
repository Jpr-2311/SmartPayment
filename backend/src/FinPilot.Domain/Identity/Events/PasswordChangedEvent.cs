using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity.Events;

/// <summary>
/// Raised when a user successfully changes their password.
/// Handlers (Phase 2.2+) may revoke all refresh tokens and notify the user.
/// </summary>
public sealed record PasswordChangedEvent(Guid UserId) : DomainEvent;
