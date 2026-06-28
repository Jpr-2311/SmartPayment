using FinPilot.Application.Identity.Constants;
using FinPilot.Domain.Identity;
using FinPilot.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="Role"/> entity.
/// Seeds the three system roles: Admin, User, Moderator.
/// </summary>
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name).IsRequired().HasMaxLength(IdentityConstants.MaxRoleNameLength);
        builder.Property(r => r.Description).HasMaxLength(IdentityConstants.MaxRoleDescriptionLength);
        builder.Property(r => r.IsSystemRole).IsRequired().HasDefaultValue(false);

        builder.HasIndex(r => r.Name).IsUnique();

        builder.Ignore(r => r.DomainEvents);

        // ── Seed Data ────────────────────────────────────────
        builder.HasData(IdentitySeedData.GetRoles());
    }
}
