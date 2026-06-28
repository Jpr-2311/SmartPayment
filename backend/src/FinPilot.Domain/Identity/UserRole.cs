namespace FinPilot.Domain.Identity;

/// <summary>
/// Join entity for the many-to-many relationship between <see cref="User"/> and <see cref="Role"/>.
/// Uses a composite primary key of (UserId, RoleId).
/// Includes audit metadata for when and by whom the role was assigned.
/// </summary>
public class UserRole
{
    /// <summary>Foreign key to the user.</summary>
    public Guid UserId { get; set; }

    /// <summary>Navigation property to the user.</summary>
    public User User { get; set; } = null!;

    /// <summary>Foreign key to the role.</summary>
    public Guid RoleId { get; set; }

    /// <summary>Navigation property to the role.</summary>
    public Role Role { get; set; } = null!;

    /// <summary>UTC timestamp when this role was assigned to the user.</summary>
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    /// <summary>Identifier of the admin/system that assigned this role.</summary>
    public string? AssignedBy { get; set; }
}
