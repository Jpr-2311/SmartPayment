namespace FinPilot.Domain.Identity;

/// <summary>
/// Join entity for the many-to-many relationship between <see cref="Role"/> and <see cref="Permission"/>.
/// Uses a composite primary key of (RoleId, PermissionId).
/// </summary>
public class RolePermission
{
    /// <summary>Foreign key to the role.</summary>
    public Guid RoleId { get; set; }

    /// <summary>Navigation property to the role.</summary>
    public Role Role { get; set; } = null!;

    /// <summary>Foreign key to the permission.</summary>
    public Guid PermissionId { get; set; }

    /// <summary>Navigation property to the permission.</summary>
    public Permission Permission { get; set; } = null!;
}
