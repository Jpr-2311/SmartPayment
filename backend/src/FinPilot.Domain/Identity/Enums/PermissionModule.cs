namespace FinPilot.Domain.Identity.Enums;

/// <summary>
/// Defines the application modules that permissions can be scoped to.
/// Used in conjunction with <see cref="PermissionAction"/> to form
/// granular permission names like "Users.Read" or "Reports.Export".
/// </summary>
public enum PermissionModule
{
    /// <summary>User management module.</summary>
    Users = 0,

    /// <summary>Financial transactions module.</summary>
    Transactions = 1,

    /// <summary>Wallet management module.</summary>
    Wallet = 2,

    /// <summary>Bill payment and recharge module.</summary>
    Bills = 3,

    /// <summary>Analytics and reporting module.</summary>
    Reports = 4,

    /// <summary>AI assistant and chat module.</summary>
    AI = 5,

    /// <summary>Admin portal module.</summary>
    Admin = 6,

    /// <summary>Application settings module.</summary>
    Settings = 7
}
