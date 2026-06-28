using FinPilot.Application.Identity.Constants;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="RefreshToken"/> entity.
/// </summary>
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.TokenHash).IsRequired().HasMaxLength(IdentityConstants.MaxTokenLength);
        builder.Property(t => t.DeviceName).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(t => t.Browser).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(t => t.IpAddress).HasMaxLength(IdentityConstants.MaxIpAddressLength);
        builder.Property(t => t.RevokedReason).HasMaxLength(IdentityConstants.MaxRevokedReasonLength);
        builder.Property(t => t.ReplacedByTokenHash).HasMaxLength(IdentityConstants.MaxTokenLength);

        builder.HasIndex(t => t.TokenHash);
        builder.HasIndex(t => t.UserId);

        builder.Ignore(t => t.IsExpired);
        builder.Ignore(t => t.IsActive);
        builder.Ignore(t => t.DomainEvents);

        builder.HasOne(t => t.User)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
