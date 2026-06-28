using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity;

/// <summary>
/// Represents a granular permission that can be assigned to roles.
/// Uses a dot-notation naming convention: "{Module}.{Action}" (e.g., "Users.Read").
/// The <see cref="Module"/> and <see cref="Action"/> properties are derived from the Name.
/// </summary>
public class Permission : BaseEntity
{
    /// <summary>
    /// Unique permission name in dot-notation format (e.g., "Users.Read", "Wallet.Manage").
    /// This is the canonical identifier used in authorization checks.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Module portion of the permission name (e.g., "Users", "Wallet").
    /// Extracted from the part before the dot in <see cref="Name"/>.
    /// </summary>
    public string Module { get; set; } = string.Empty;

    /// <summary>
    /// Action portion of the permission name (e.g., "Read", "Manage").
    /// Extracted from the part after the dot in <see cref="Name"/>.
    /// </summary>
    public string Action { get; set; } = string.Empty;

    /// <summary>Human-readable description of what this permission grants.</summary>
    public string? Description { get; set; }

    // ── Navigation Properties ────────────────────────────────

    /// <summary>Roles that have been granted this permission.</summary>
    public ICollection<RolePermission> RolePermissions { get; set; } = [];
}
