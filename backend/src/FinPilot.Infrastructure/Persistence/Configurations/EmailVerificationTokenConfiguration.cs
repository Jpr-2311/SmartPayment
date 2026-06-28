using FinPilot.Application.Identity.Constants;
using FinPilot.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPilot.Infrastructure.Persistence.Configurations;

/// <summary>
/// EF Core Fluent API configuration for the <see cref="EmailVerificationToken"/> entity.
/// </summary>
public class EmailVerificationTokenConfiguration : IEntityTypeConfiguration<EmailVerificationToken>
{
    public void Configure(EntityTypeBuilder<EmailVerificationToken> builder)
    {
        builder.ToTable("email_verification_tokens");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Token).IsRequired().HasMaxLength(IdentityConstants.MaxTokenLength);

        builder.HasIndex(t => t.Token);
        builder.HasIndex(t => t.UserId);

        builder.Ignore(t => t.IsExpired);
        builder.Ignore(t => t.IsValid);
        builder.Ignore(t => t.DomainEvents);

        builder.HasOne(t => t.User)
            .WithMany(u => u.EmailVerificationTokens)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
