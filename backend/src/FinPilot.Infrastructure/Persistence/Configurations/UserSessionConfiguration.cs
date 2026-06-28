using FinPilot.Application.Identity.Constants;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="UserSession"/> entity.
/// </summary>
public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("user_sessions");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.SessionToken).IsRequired().HasMaxLength(IdentityConstants.MaxTokenLength);
        builder.Property(s => s.DeviceName).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(s => s.Browser).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(s => s.OperatingSystem).HasMaxLength(IdentityConstants.MaxDeviceInfoLength);
        builder.Property(s => s.IpAddress).HasMaxLength(IdentityConstants.MaxIpAddressLength);

        builder.HasIndex(s => s.SessionToken).IsUnique();
        builder.HasIndex(s => s.UserId);

        builder.Ignore(s => s.IsExpired);
        builder.Ignore(s => s.IsValid);
        builder.Ignore(s => s.DomainEvents);

        builder.HasOne(s => s.User)
            .WithMany(u => u.Sessions)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
