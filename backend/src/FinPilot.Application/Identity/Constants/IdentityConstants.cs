namespace FinPilot.Application.Identity.Constants;

/// <summary>
/// Identity-specific constants used across the application.
/// Centralizes string lengths, policy values, and token durations.
/// </summary>
public static class IdentityConstants
{
    // ── String Lengths ───────────────────────────────────────

    /// <summary>Maximum length for first and last names.</summary>
    public const int MaxNameLength = 100;

    /// <summary>Minimum length for usernames.</summary>
    public const int MinUsernameLength = 3;

    /// <summary>Maximum length for usernames.</summary>
    public const int MaxUsernameLength = 30;

    /// <summary>Maximum length for email addresses.</summary>
    public const int MaxEmailLength = 256;

    /// <summary>Maximum length for phone numbers (including country code).</summary>
    public const int MaxPhoneLength = 20;

    /// <summary>Maximum length for password hashes.</summary>
    public const int MaxPasswordHashLength = 512;

    /// <summary>Maximum length for profile image URLs.</summary>
    public const int MaxProfileImageUrlLength = 2048;

    /// <summary>Maximum length for country codes.</summary>
    public const int MaxCountryLength = 10;

    /// <summary>Maximum length for time zone identifiers.</summary>
    public const int MaxTimeZoneLength = 50;

    /// <summary>Maximum length for currency codes.</summary>
    public const int MaxCurrencyLength = 10;

    /// <summary>Maximum length for language preference tags.</summary>
    public const int MaxLanguageLength = 20;

    /// <summary>Maximum length for role names.</summary>
    public const int MaxRoleNameLength = 50;

    /// <summary>Maximum length for role descriptions.</summary>
    public const int MaxRoleDescriptionLength = 256;

    /// <summary>Maximum length for permission names.</summary>
    public const int MaxPermissionNameLength = 100;

    /// <summary>Maximum length for permission module names.</summary>
    public const int MaxPermissionModuleLength = 50;

    /// <summary>Maximum length for permission action names.</summary>
    public const int MaxPermissionActionLength = 50;

    /// <summary>Maximum length for permission descriptions.</summary>
    public const int MaxPermissionDescriptionLength = 256;

    /// <summary>Maximum length for token strings.</summary>
    public const int MaxTokenLength = 512;

    /// <summary>Maximum length for IP address strings.</summary>
    public const int MaxIpAddressLength = 45;

    /// <summary>Maximum length for device/browser/OS name strings.</summary>
    public const int MaxDeviceInfoLength = 256;

    /// <summary>Maximum length for country/city names in login history.</summary>
    public const int MaxGeoLocationLength = 100;

    /// <summary>Maximum length for failure reason strings.</summary>
    public const int MaxFailureReasonLength = 500;

    /// <summary>Maximum length for revocation reason strings.</summary>
    public const int MaxRevokedReasonLength = 256;

    // ── Password Policy ──────────────────────────────────────

    /// <summary>Minimum password length.</summary>
    public const int MinPasswordLength = 8;

    /// <summary>Maximum password length (before hashing).</summary>
    public const int MaxPasswordLength = 128;

    // ── Lockout Policy ───────────────────────────────────────

    /// <summary>Maximum failed login attempts before lockout.</summary>
    public const int MaxFailedLoginAttempts = 5;

    /// <summary>Default lockout duration in minutes.</summary>
    public const int DefaultLockoutMinutes = 30;

    // ── Token Expiry ─────────────────────────────────────────

    /// <summary>Email verification token validity in hours.</summary>
    public const int EmailVerificationTokenExpiryHours = 24;

    /// <summary>Password reset token validity in hours.</summary>
    public const int PasswordResetTokenExpiryHours = 2;

    /// <summary>Refresh token validity in days.</summary>
    public const int RefreshTokenExpiryDays = 30;

    /// <summary>User session validity in days.</summary>
    public const int SessionExpiryDays = 30;

    // ── Seeded Role Names ────────────────────────────────────

    /// <summary>System admin role name.</summary>
    public const string AdminRole = "Admin";

    /// <summary>Default user role name.</summary>
    public const string UserRole = "User";

    /// <summary>Moderator role name.</summary>
    public const string ModeratorRole = "Moderator";
}
