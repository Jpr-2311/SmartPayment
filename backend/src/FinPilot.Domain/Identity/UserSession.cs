using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity;

/// <summary>
/// Tracks an active user session for multi-device management.
/// Supports "logout everywhere" and per-device session termination.
/// </summary>
public class UserSession : BaseEntity
{
    /// <summary>Unique session identifier token (hashed).</summary>
    public string SessionToken { get; set; } = string.Empty;

    /// <summary>UTC timestamp when this session expires.</summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>Whether this session is currently active.</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Device name or model for this session.</summary>
    public string? DeviceName { get; set; }

    /// <summary>Browser name for this session.</summary>
    public string? Browser { get; set; }

    /// <summary>Operating system for this session.</summary>
    public string? OperatingSystem { get; set; }

    /// <summary>IP address from which this session was created.</summary>
    public string? IpAddress { get; set; }

    /// <summary>UTC timestamp of the last activity on this session.</summary>
    public DateTime? LastActivityAt { get; set; }

    // ── Relationships ────────────────────────────────────────

    /// <summary>Foreign key to the session owner.</summary>
    public Guid UserId { get; set; }

    /// <summary>Navigation property to the session owner.</summary>
    public User User { get; set; } = null!;

    // ── Computed Properties ──────────────────────────────────

    /// <summary>Whether this session has expired.</summary>
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

    /// <summary>Whether this session is currently valid (active and not expired).</summary>
    public bool IsValid => IsActive && !IsExpired;

    // ── Domain Methods ───────────────────────────────────────

    /// <summary>
    /// Deactivates this session (e.g., on logout).
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
    }

    /// <summary>
    /// Updates the last activity timestamp to keep the session alive.
    /// </summary>
    public void RecordActivity()
    {
        LastActivityAt = DateTime.UtcNow;
    }
}
