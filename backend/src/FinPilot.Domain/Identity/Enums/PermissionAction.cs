namespace FinPilot.Domain.Identity.Enums;

/// <summary>
/// Defines the actions that can be permitted on a module.
/// Used in conjunction with <see cref="PermissionModule"/> to form
/// granular permission names like "Users.Read" or "Wallet.Manage".
/// </summary>
public enum PermissionAction
{
    /// <summary>View / list resources.</summary>
    Read = 0,

    /// <summary>Modify existing resources.</summary>
    Write = 1,

    /// <summary>Create new resources.</summary>
    Create = 2,

    /// <summary>Remove resources.</summary>
    Delete = 3,

    /// <summary>Export resources to files or reports.</summary>
    Export = 4,

    /// <summary>Full management access including configuration.</summary>
    Manage = 5
}
