using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity;

/// <summary>
/// Audit trail record for every login attempt (successful or failed).
/// Used for security monitoring and future dashboard analytics.
/// </summary>
public class LoginHistory : BaseEntity
{
    /// <summary>UTC timestamp when the login attempt occurred.</summary>
    public DateTime LoginTime { get; set; } = DateTime.UtcNow;

    /// <summary>IP address of the client making the attempt.</summary>
    public string? IpAddress { get; set; }

    /// <summary>Device name or model from the user agent.</summary>
    public string? DeviceName { get; set; }

    /// <summary>Browser name parsed from the user agent string.</summary>
    public string? Browser { get; set; }

    /// <summary>Operating system parsed from the user agent string.</summary>
    public string? OperatingSystem { get; set; }

    /// <summary>Country determined from GeoIP lookup of the IP address.</summary>
    public string? Country { get; set; }

    /// <summary>City determined from GeoIP lookup of the IP address.</summary>
    public string? City { get; set; }

    /// <summary>Whether the login attempt was successful.</summary>
    public bool IsSuccessful { get; set; }

    /// <summary>Reason for failure if the attempt was unsuccessful.</summary>
    public string? FailureReason { get; set; }

    // ── Relationships ────────────────────────────────────────

    /// <summary>Foreign key to the user who attempted login.</summary>
    public Guid UserId { get; set; }

    /// <summary>Navigation property to the user.</summary>
    public User User { get; set; } = null!;
}
