using FinPilot.Domain.Identity;

namespace FinPilot.Infrastructure.Persistence.Seed;

/// <summary>
/// Static seed data for the identity system.
/// Uses deterministic GUIDs to ensure idempotent migrations across all environments.
/// Referenced by entity configurations via <c>HasData()</c>.
/// </summary>
public static class IdentitySeedData
{
    // ── Role GUIDs ───────────────────────────────────────────

    /// <summary>Deterministic GUID for the Admin role.</summary>
    public static readonly Guid AdminRoleId = new("A1B2C3D4-E5F6-4A5B-8C9D-0E1F2A3B4C5D");

    /// <summary>Deterministic GUID for the User role.</summary>
    public static readonly Guid UserRoleId = new("B2C3D4E5-F6A7-4B5C-9D0E-1F2A3B4C5D6E");

    /// <summary>Deterministic GUID for the Moderator role.</summary>
    public static readonly Guid ModeratorRoleId = new("C3D4E5F6-A7B8-4C5D-0E1F-2A3B4C5D6E7F");

    // ── Permission GUIDs ─────────────────────────────────────
    // Organized by module for readability.

    // Users module
    public static readonly Guid UsersReadId =      new("10000000-0000-0000-0000-000000000001");
    public static readonly Guid UsersWriteId =     new("10000000-0000-0000-0000-000000000002");
    public static readonly Guid UsersCreateId =    new("10000000-0000-0000-0000-000000000003");
    public static readonly Guid UsersDeleteId =    new("10000000-0000-0000-0000-000000000004");
    public static readonly Guid UsersManageId =    new("10000000-0000-0000-0000-000000000005");

    // Transactions module
    public static readonly Guid TransactionsReadId =   new("20000000-0000-0000-0000-000000000001");
    public static readonly Guid TransactionsCreateId = new("20000000-0000-0000-0000-000000000002");
    public static readonly Guid TransactionsExportId = new("20000000-0000-0000-0000-000000000003");

    // Wallet module
    public static readonly Guid WalletReadId =   new("30000000-0000-0000-0000-000000000001");
    public static readonly Guid WalletManageId = new("30000000-0000-0000-0000-000000000002");

    // Bills module
    public static readonly Guid BillsReadId = new("40000000-0000-0000-0000-000000000001");
    public static readonly Guid BillsPayId =  new("40000000-0000-0000-0000-000000000002");

    // Reports module
    public static readonly Guid ReportsReadId =   new("50000000-0000-0000-0000-000000000001");
    public static readonly Guid ReportsExportId = new("50000000-0000-0000-0000-000000000002");

    // AI module
    public static readonly Guid AiChatId = new("60000000-0000-0000-0000-000000000001");

    // Admin module
    public static readonly Guid AdminReadId =   new("70000000-0000-0000-0000-000000000001");
    public static readonly Guid AdminManageId = new("70000000-0000-0000-0000-000000000002");

    // Settings module
    public static readonly Guid SettingsReadId =   new("80000000-0000-0000-0000-000000000001");
    public static readonly Guid SettingsManageId = new("80000000-0000-0000-0000-000000000002");

    // ── Seed Roles ───────────────────────────────────────────

    /// <summary>Returns the seeded roles.</summary>
    public static Role[] GetRoles() =>
    [
        new Role { Id = AdminRoleId,     Name = "Admin",     Description = "Full system access. Can manage all users, settings, and data.",        IsSystemRole = true },
        new Role { Id = UserRoleId,      Name = "User",      Description = "Standard user with access to personal finance features.",              IsSystemRole = true },
        new Role { Id = ModeratorRoleId, Name = "Moderator", Description = "Can moderate content and manage user reports. Limited admin access.", IsSystemRole = true },
    ];

    // ── Seed Permissions ─────────────────────────────────────

    /// <summary>Returns the seeded permissions.</summary>
    public static Permission[] GetPermissions() =>
    [
        // Users
        new Permission { Id = UsersReadId,      Name = "Users.Read",      Module = "Users",        Action = "Read",   Description = "View user profiles and lists" },
        new Permission { Id = UsersWriteId,     Name = "Users.Write",     Module = "Users",        Action = "Write",  Description = "Modify user profiles" },
        new Permission { Id = UsersCreateId,    Name = "Users.Create",    Module = "Users",        Action = "Create", Description = "Create new user accounts" },
        new Permission { Id = UsersDeleteId,    Name = "Users.Delete",    Module = "Users",        Action = "Delete", Description = "Delete user accounts" },
        new Permission { Id = UsersManageId,    Name = "Users.Manage",    Module = "Users",        Action = "Manage", Description = "Full user management including roles" },

        // Transactions
        new Permission { Id = TransactionsReadId,   Name = "Transactions.Read",   Module = "Transactions", Action = "Read",   Description = "View transaction history" },
        new Permission { Id = TransactionsCreateId, Name = "Transactions.Create", Module = "Transactions", Action = "Create", Description = "Create new transactions" },
        new Permission { Id = TransactionsExportId, Name = "Transactions.Export", Module = "Transactions", Action = "Export", Description = "Export transaction data" },

        // Wallet
        new Permission { Id = WalletReadId,   Name = "Wallet.Read",   Module = "Wallet", Action = "Read",   Description = "View wallet balances" },
        new Permission { Id = WalletManageId, Name = "Wallet.Manage", Module = "Wallet", Action = "Manage", Description = "Manage wallets and transfers" },

        // Bills
        new Permission { Id = BillsReadId, Name = "Bills.Read", Module = "Bills", Action = "Read", Description = "View bills and payment history" },
        new Permission { Id = BillsPayId,  Name = "Bills.Pay",  Module = "Bills", Action = "Pay",  Description = "Make bill payments" },

        // Reports
        new Permission { Id = ReportsReadId,   Name = "Reports.Read",   Module = "Reports", Action = "Read",   Description = "View reports and analytics" },
        new Permission { Id = ReportsExportId, Name = "Reports.Export", Module = "Reports", Action = "Export", Description = "Export reports to files" },

        // AI
        new Permission { Id = AiChatId, Name = "AI.Chat", Module = "AI", Action = "Chat", Description = "Use the AI financial assistant" },

        // Admin
        new Permission { Id = AdminReadId,   Name = "Admin.Read",   Module = "Admin", Action = "Read",   Description = "View admin dashboard" },
        new Permission { Id = AdminManageId, Name = "Admin.Manage", Module = "Admin", Action = "Manage", Description = "Manage system configuration" },

        // Settings
        new Permission { Id = SettingsReadId,   Name = "Settings.Read",   Module = "Settings", Action = "Read",   Description = "View application settings" },
        new Permission { Id = SettingsManageId, Name = "Settings.Manage", Module = "Settings", Action = "Manage", Description = "Modify application settings" },
    ];

    // ── Admin Role ↔ All Permissions ─────────────────────────

    /// <summary>Returns role-permission mappings granting Admin all permissions.</summary>
    public static RolePermission[] GetAdminRolePermissions()
    {
        var permissions = GetPermissions();
        return permissions.Select(p => new RolePermission
        {
            RoleId = AdminRoleId,
            PermissionId = p.Id,
        }).ToArray();
    }

    /// <summary>Returns role-permission mappings for the standard User role.</summary>
    public static RolePermission[] GetUserRolePermissions() =>
    [
        new RolePermission { RoleId = UserRoleId, PermissionId = TransactionsReadId },
        new RolePermission { RoleId = UserRoleId, PermissionId = TransactionsCreateId },
        new RolePermission { RoleId = UserRoleId, PermissionId = WalletReadId },
        new RolePermission { RoleId = UserRoleId, PermissionId = WalletManageId },
        new RolePermission { RoleId = UserRoleId, PermissionId = BillsReadId },
        new RolePermission { RoleId = UserRoleId, PermissionId = BillsPayId },
        new RolePermission { RoleId = UserRoleId, PermissionId = ReportsReadId },
        new RolePermission { RoleId = UserRoleId, PermissionId = ReportsExportId },
        new RolePermission { RoleId = UserRoleId, PermissionId = AiChatId },
        new RolePermission { RoleId = UserRoleId, PermissionId = SettingsReadId },
    ];

    /// <summary>Returns all role-permission seed data.</summary>
    public static RolePermission[] GetAllRolePermissions()
    {
        return [.. GetAdminRolePermissions(), .. GetUserRolePermissions()];
    }
}
