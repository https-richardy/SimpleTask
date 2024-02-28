using FluentValidation;
using HttpsRichardy.SimpleTask.Application.AccountContext.Queries;

namespace HttpsRichardy.SimpleTask.Application.AccountContext.Validation;

public class AuthenticationQueryValidator : AbstractValidator<AuthenticationQuery>, IValidator<AuthenticationQuery>
{
    public AuthenticationQueryValidator()
    {
        RuleFor(query => query.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be valid.");

        RuleFor(query => query.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.");
    }
}