using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity;

/// <summary>
/// Stores a hashed refresh token issued to a user.
/// Tracks device/browser/IP metadata for session management.
/// Tokens are hashed before storage — the plain token is never persisted.
/// </summary>
public class RefreshToken : BaseEntity
{
    /// <summary>SHA-256 hash of the refresh token value.</summary>
    public string TokenHash { get; set; } = string.Empty;

    /// <summary>UTC timestamp when this token expires.</summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>Device name or model from the user agent.</summary>
    public string? DeviceName { get; set; }

    /// <summary>Browser name parsed from the user agent string.</summary>
    public string? Browser { get; set; }

    /// <summary>IP address of the client that requested this token.</summary>
    public string? IpAddress { get; set; }

    /// <summary>Whether this token has been revoked (e.g., by logout).</summary>
    public bool IsRevoked { get; set; }

    /// <summary>UTC timestamp when the token was revoked. Null if still active.</summary>
    public DateTime? RevokedAt { get; set; }

    /// <summary>Reason for revocation (e.g., "Logout", "Token rotation", "Suspicious activity").</summary>
    public string? RevokedReason { get; set; }

    /// <summary>Hash of the replacement token if this one was rotated.</summary>
    public string? ReplacedByTokenHash { get; set; }

    // ── Relationships ────────────────────────────────────────

    /// <summary>Foreign key to the user who owns this token.</summary>
    public Guid UserId { get; set; }

    /// <summary>Navigation property to the owning user.</summary>
    public User User { get; set; } = null!;

    // ── Computed Properties ──────────────────────────────────

    /// <summary>Whether this token has expired.</summary>
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

    /// <summary>Whether this token is currently valid (not expired and not revoked).</summary>
    public bool IsActive => !IsRevoked && !IsExpired;

    // ── Domain Methods ───────────────────────────────────────

    /// <summary>
    /// Revokes this refresh token with a reason and optional replacement hash.
    /// </summary>
    public void Revoke(string reason, string? replacedByTokenHash = null)
    {
        IsRevoked = true;
        RevokedAt = DateTime.UtcNow;
        RevokedReason = reason;
        ReplacedByTokenHash = replacedByTokenHash;
    }
}
