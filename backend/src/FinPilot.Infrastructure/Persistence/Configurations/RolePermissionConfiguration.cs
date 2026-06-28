using FinPilot.Domain.Identity;
using FinPilot.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="RolePermission"/> join entity.
/// Uses a composite primary key (RoleId, PermissionId).
/// Seeds Admin role with all permissions, User role with standard permissions.
/// </summary>
public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("role_permissions");

        // ── Composite Primary Key ────────────────────────────
        builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

        // ── Relationships ────────────────────────────────────
        builder.HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        // ── Seed Data ────────────────────────────────────────
        builder.HasData(IdentitySeedData.GetAllRolePermissions());
    }
}
