using FinPilot.Application.Identity.Constants;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="User"/> entity.
/// Defines table structure, indexes, constraints, and concurrency.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        // ── Properties ───────────────────────────────────────
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(IdentityConstants.MaxNameLength);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(IdentityConstants.MaxNameLength);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(IdentityConstants.MaxUsernameLength);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(IdentityConstants.MaxEmailLength);
        builder.Property(u => u.PhoneNumber).HasMaxLength(IdentityConstants.MaxPhoneLength);
        builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(IdentityConstants.MaxPasswordHashLength);
        builder.Property(u => u.ProfileImageUrl).HasMaxLength(IdentityConstants.MaxProfileImageUrlLength);
        builder.Property(u => u.Country).HasMaxLength(IdentityConstants.MaxCountryLength);
        builder.Property(u => u.TimeZone).IsRequired().HasMaxLength(IdentityConstants.MaxTimeZoneLength).HasDefaultValue("UTC");
        builder.Property(u => u.CurrencyPreference).IsRequired().HasMaxLength(IdentityConstants.MaxCurrencyLength).HasDefaultValue("USD");
        builder.Property(u => u.LanguagePreference).IsRequired().HasMaxLength(IdentityConstants.MaxLanguageLength).HasDefaultValue("en-US");
        builder.Property(u => u.IsActive).IsRequired().HasDefaultValue(true);
        builder.Property(u => u.IsLocked).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.IsEmailVerified).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.IsPhoneVerified).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.FailedLoginAttempts).IsRequired().HasDefaultValue(0);
        builder.Property(u => u.IsDeleted).IsRequired().HasDefaultValue(false);

        // ── Concurrency Token (PostgreSQL xmin system column) ──
        builder.Property(u => u.RowVersion)
            .HasColumnName("xmin")
            .HasColumnType("xid")
            .IsRowVersion();

        // ── Indexes ──────────────────────────────────────────
        builder.HasIndex(u => u.Email).IsUnique().HasFilter("\"IsDeleted\" = false");
        builder.HasIndex(u => u.Username).IsUnique().HasFilter("\"IsDeleted\" = false");
        builder.HasIndex(u => u.PhoneNumber).HasFilter("\"PhoneNumber\" IS NOT NULL AND \"IsDeleted\" = false");
        builder.HasIndex(u => u.IsActive);

        // ── Query Filter (soft delete) ───────────────────────
        builder.HasQueryFilter(u => !u.IsDeleted);

        // ── Ignore computed properties ───────────────────────
        builder.Ignore(u => u.FullName);
        builder.Ignore(u => u.IsLockoutExpired);
        builder.Ignore(u => u.DomainEvents);
    }
}
