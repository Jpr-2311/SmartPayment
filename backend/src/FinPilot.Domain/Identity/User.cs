using FinPilot.Domain.Common;
using FinPilot.Domain.Identity.Events;

namespace FinPilot.Domain.Identity;

/// <summary>
/// Core identity entity representing an application user.
/// Acts as the aggregate root for the identity bounded context.
/// Encapsulates business rules for lockout, verification, and password management.
/// </summary>
public class User : BaseAuditableEntity
{
    // ── Personal Information ─────────────────────────────────

    /// <summary>User's first name.</summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>User's last name.</summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>Unique username for login and display.</summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>Unique email address. Used for login and verification.</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>Optional phone number with country code.</summary>
    public string? PhoneNumber { get; set; }

    /// <summary>Bcrypt/Argon2 hashed password. Never stored in plain text.</summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>URL to the user's profile image in object storage.</summary>
    public string? ProfileImageUrl { get; set; }

    /// <summary>User's date of birth. Used for age verification.</summary>
    public DateOnly? DateOfBirth { get; set; }

    // ── Locale & Preferences ─────────────────────────────────

    /// <summary>ISO 3166-1 alpha-2 country code (e.g., "US", "IN").</summary>
    public string? Country { get; set; }

    /// <summary>IANA time zone identifier (e.g., "Asia/Kolkata").</summary>
    public string TimeZone { get; set; } = "UTC";

    /// <summary>ISO 4217 currency code preference (e.g., "USD", "INR").</summary>
    public string CurrencyPreference { get; set; } = "USD";

    /// <summary>BCP 47 language tag (e.g., "en-US", "hi-IN").</summary>
    public string LanguagePreference { get; set; } = "en-US";

    // ── Verification ─────────────────────────────────────────

    /// <summary>Whether the user has verified their email address.</summary>
    public bool IsEmailVerified { get; set; }

    /// <summary>Whether the user has verified their phone number.</summary>
    public bool IsPhoneVerified { get; set; }

    // ── Account Status ───────────────────────────────────────

    /// <summary>Whether the account is active. Inactive accounts cannot log in.</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Whether the account is locked due to failed login attempts.</summary>
    public bool IsLocked { get; set; }

    /// <summary>Number of consecutive failed login attempts.</summary>
    public int FailedLoginAttempts { get; set; }

    /// <summary>UTC timestamp when the lockout expires. Null if not locked.</summary>
    public DateTime? LockoutEnd { get; set; }

    // ── Timestamps ───────────────────────────────────────────

    /// <summary>UTC timestamp of the user's last successful login.</summary>
    public DateTime? LastLoginAt { get; set; }

    /// <summary>UTC timestamp when the password was last changed.</summary>
    public DateTime? LastPasswordChangedAt { get; set; }

    // ── Computed Properties ──────────────────────────────────

    /// <summary>Full display name combining first and last name.</summary>
    public string FullName => $"{FirstName} {LastName}".Trim();

    /// <summary>Whether the lockout period has expired.</summary>
    public bool IsLockoutExpired => LockoutEnd.HasValue && LockoutEnd.Value <= DateTime.UtcNow;

    // ── Navigation Properties ────────────────────────────────

    /// <summary>Roles assigned to this user.</summary>
    public ICollection<UserRole> UserRoles { get; set; } = [];

    /// <summary>Refresh tokens issued to this user.</summary>
    public ICollection<RefreshToken> RefreshTokens { get; set; } = [];

    /// <summary>Email verification tokens for this user.</summary>
    public ICollection<EmailVerificationToken> EmailVerificationTokens { get; set; } = [];

    /// <summary>Password reset tokens for this user.</summary>
    public ICollection<PasswordResetToken> PasswordResetTokens { get; set; } = [];

    /// <summary>Login history records for this user.</summary>
    public ICollection<LoginHistory> LoginHistory { get; set; } = [];

    /// <summary>Active sessions for this user.</summary>
    public ICollection<UserSession> Sessions { get; set; } = [];

    // ── Domain Methods ───────────────────────────────────────

    /// <summary>
    /// Records a failed login attempt. Locks the account after exceeding the threshold.
    /// </summary>
    /// <param name="maxFailedAttempts">Maximum allowed failed attempts before lockout.</param>
    /// <param name="lockoutDuration">Duration of the lockout period.</param>
    public void RecordFailedLoginAttempt(int maxFailedAttempts = 5, TimeSpan? lockoutDuration = null)
    {
        FailedLoginAttempts++;

        if (FailedLoginAttempts >= maxFailedAttempts)
        {
            Lock(lockoutDuration ?? TimeSpan.FromMinutes(30));
        }
    }

    /// <summary>
    /// Records a successful login, resetting failed attempt counters.
    /// </summary>
    public void RecordSuccessfulLogin()
    {
        FailedLoginAttempts = 0;
        IsLocked = false;
        LockoutEnd = null;
        LastLoginAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Locks the user account for the specified duration.
    /// Raises a <see cref="UserLockedEvent"/>.
    /// </summary>
    public void Lock(TimeSpan duration)
    {
        IsLocked = true;
        LockoutEnd = DateTime.UtcNow.Add(duration);
        RaiseDomainEvent(new UserLockedEvent(Id, LockoutEnd.Value));
    }

    /// <summary>
    /// Unlocks the user account immediately.
    /// </summary>
    public void Unlock()
    {
        IsLocked = false;
        LockoutEnd = null;
        FailedLoginAttempts = 0;
    }

    /// <summary>
    /// Marks the user's email as verified.
    /// Raises an <see cref="EmailVerifiedEvent"/>.
    /// </summary>
    public void VerifyEmail()
    {
        IsEmailVerified = true;
        RaiseDomainEvent(new EmailVerifiedEvent(Id, Email));
    }

    /// <summary>
    /// Marks the user's phone as verified.
    /// </summary>
    public void VerifyPhone()
    {
        IsPhoneVerified = true;
    }

    /// <summary>
    /// Updates the password hash and records the change timestamp.
    /// Raises a <see cref="PasswordChangedEvent"/>.
    /// </summary>
    /// <param name="newPasswordHash">The new hashed password.</param>
    public void ChangePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        LastPasswordChangedAt = DateTime.UtcNow;
        RaiseDomainEvent(new PasswordChangedEvent(Id));
    }

    /// <summary>
    /// Deactivates the user account.
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
    }

    /// <summary>
    /// Reactivates a deactivated user account.
    /// </summary>
    public void Activate()
    {
        IsActive = true;
    }
}
