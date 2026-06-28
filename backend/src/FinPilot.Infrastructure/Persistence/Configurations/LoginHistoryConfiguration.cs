using FinPilot.Application.Identity.Constants;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="LoginHistory"/> entity.
/// </summary>
public class LoginHistoryConfiguration : IEntityTypeConfiguration<LoginHistory>
{
    public void Configure(EntityTypeBuilder<LoginHistory> builder)
    {
        builder.ToTable("login_history");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.IpAddress).HasMaxLength(IdentityConstants.MaxIpAddressLength);
        builder.Property(h => h.DeviceName).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(h => h.Browser).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(h => h.OperatingSystem).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(h => h.Country).HasMaxLength(IdentityConstants.MaxGeoLocationLength);
        builder.Property(h => h.City).HasMaxLength(IdentityConstants.MaxGeoLocationLength);
        builder.Property(h => h.FailureReason).HasMaxLength(IdentityConstants.MaxFailureReasonLength);

        // Composite index for efficient user history queries (most recent first)
        builder.HasIndex(h => new { h.UserId, h.LoginTime })
            .IsDescending(false, true);

        builder.Ignore(h => h.DomainEvents);

        builder.HasOne(h => h.User)
            .WithMany(u => u.LoginHistory)
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
