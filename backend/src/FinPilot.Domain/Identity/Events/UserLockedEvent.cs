using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity.Events;

/// <summary>
/// Raised when a user account is locked due to excessive failed login attempts.
/// Handlers (Phase 2.2+) may send security alert emails or log to SIEM.
/// </summary>
public sealed record UserLockedEvent(Guid UserId, DateTime LockoutEnd) : DomainEvent;
