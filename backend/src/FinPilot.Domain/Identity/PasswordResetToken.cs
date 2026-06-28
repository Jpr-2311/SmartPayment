using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity;

/// <summary>
/// One-time token used for password reset flows.
/// Tokens expire after a configured duration and can only be used once.
/// </summary>
public class PasswordResetToken : BaseEntity
{
    /// <summary>The password reset token value.</summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>UTC timestamp when this token expires.</summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>Whether this token has been used to reset a password.</summary>
    public bool IsUsed { get; set; }

    /// <summary>UTC timestamp when the token was used. Null if unused.</summary>
    public DateTime? UsedAt { get; set; }

    // ── Relationships ────────────────────────────────────────

    /// <summary>Foreign key to the user requesting the reset.</summary>
    public Guid UserId { get; set; }

    /// <summary>Navigation property to the user.</summary>
    public User User { get; set; } = null!;

    // ── Computed Properties ──────────────────────────────────

    /// <summary>Whether this token has expired.</summary>
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

    /// <summary>Whether this token can still be used.</summary>
    public bool IsValid => !IsUsed && !IsExpired;

    // ── Domain Methods ───────────────────────────────────────

    /// <summary>
    /// Marks this token as consumed.
    /// </summary>
    public void MarkUsed()
    {
        IsUsed = true;
        UsedAt = DateTime.UtcNow;
    }
}
