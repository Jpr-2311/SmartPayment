using FinPilot.Application.Identity.Constants;
using FinPilot.Domain.Identity;
using FinPilot.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="Permission"/> entity.
/// Seeds all granular permissions organized by module.
/// </summary>
public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(IdentityConstants.MaxPermissionNameLength);
        builder.Property(p => p.Module).IsRequired().HasMaxLength(IdentityConstants.MaxPermissionModuleLength);
        builder.Property(p => p.Action).IsRequired().HasMaxLength(IdentityConstants.MaxPermissionActionLength);
        builder.Property(p => p.Description).HasMaxLength(IdentityConstants.MaxPermissionDescriptionLength);

        builder.HasIndex(p => p.Name).IsUnique();
        builder.HasIndex(p => p.Module);

        builder.Ignore(p => p.DomainEvents);

        // ── Seed Data ────────────────────────────────────────
        builder.HasData(IdentitySeedData.GetPermissions());
    }
}
