using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity.Events;

/// <summary>
/// Raised when a user's email address is successfully verified.
/// Handlers (Phase 2.2+) may unlock full platform features.
/// </summary>
public sealed record EmailVerifiedEvent(Guid UserId, string Email) : DomainEvent;
