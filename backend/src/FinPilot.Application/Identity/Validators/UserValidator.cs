using FluentValidation;
using FinPilot.Domain.Identity;
using FinPilot.Application.Identity.Constants;

namespace FinPilot.Application.Identity.Validators;

/// <summary>
/// FluentValidation rules for the <see cref="User"/> entity.
/// Validates field formats, lengths, and required fields.
/// Used by the application layer before persisting user data.
/// </summary>
public class UserValidator : AbstractValidator<User>
{
    /// <summary>
    /// Initializes validation rules for the User entity.
    /// </summary>
    public UserValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(IdentityConstants.MaxNameLength)
            .WithMessage($"First name must not exceed {IdentityConstants.MaxNameLength} characters.");

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(IdentityConstants.MaxNameLength)
            .WithMessage($"Last name must not exceed {IdentityConstants.MaxNameLength} characters.");

        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(IdentityConstants.MinUsernameLength)
            .WithMessage($"Username must be at least {IdentityConstants.MinUsernameLength} characters.")
            .MaximumLength(IdentityConstants.MaxUsernameLength)
            .WithMessage($"Username must not exceed {IdentityConstants.MaxUsernameLength} characters.")
            .Matches(@"^[a-zA-Z0-9._-]+$")
            .WithMessage("Username can only contain letters, numbers, dots, hyphens, and underscores.");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(IdentityConstants.MaxEmailLength)
            .WithMessage($"Email must not exceed {IdentityConstants.MaxEmailLength} characters.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(u => u.PhoneNumber)
            .MaximumLength(IdentityConstants.MaxPhoneLength)
            .WithMessage($"Phone number must not exceed {IdentityConstants.MaxPhoneLength} characters.")
            .Matches(@"^\+?[1-9]\d{6,14}$")
            .WithMessage("Phone number must be in international format (e.g., +14155552671).")
            .When(u => !string.IsNullOrWhiteSpace(u.PhoneNumber));

        RuleFor(u => u.PasswordHash)
            .NotEmpty().WithMessage("Password hash must not be empty.");

        RuleFor(u => u.ProfileImageUrl)
            .MaximumLength(IdentityConstants.MaxProfileImageUrlLength)
            .When(u => !string.IsNullOrWhiteSpace(u.ProfileImageUrl));

        RuleFor(u => u.Country)
            .MaximumLength(IdentityConstants.MaxCountryLength)
            .When(u => !string.IsNullOrWhiteSpace(u.Country));

        RuleFor(u => u.TimeZone)
            .MaximumLength(IdentityConstants.MaxTimeZoneLength);

        RuleFor(u => u.CurrencyPreference)
            .MaximumLength(IdentityConstants.MaxCurrencyLength);

        RuleFor(u => u.LanguagePreference)
            .MaximumLength(IdentityConstants.MaxLanguageLength);

        RuleFor(u => u.FailedLoginAttempts)
            .GreaterThanOrEqualTo(0).WithMessage("Failed login attempts cannot be negative.");
    }
}
