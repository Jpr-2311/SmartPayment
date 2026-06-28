using FinPilot.Domain.Common;

namespace FinPilot.Domain.Identity;

/// <summary>
/// Represents a security role that groups permissions.
/// Roles are assigned to users via <see cref="UserRole"/>.
/// System roles (Admin, User, Moderator) cannot be deleted.
/// </summary>
public class Role : BaseEntity
{
    /// <summary>Unique role name (e.g., "Admin", "User").</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Human-readable description of the role's purpose.</summary>
    public string? Description { get; set; }

    /// <summary>
    /// System roles are seeded at startup and cannot be deleted or renamed.
    /// Prevents accidental removal of essential roles.
    /// </summary>
    public bool IsSystemRole { get; set; }

    // ── Navigation Properties ────────────────────────────────

    /// <summary>Users assigned to this role.</summary>
    public ICollection<UserRole> UserRoles { get; set; } = [];

    /// <summary>Permissions granted to this role.</summary>
    public ICollection<RolePermission> RolePermissions { get; set; } = [];
}
