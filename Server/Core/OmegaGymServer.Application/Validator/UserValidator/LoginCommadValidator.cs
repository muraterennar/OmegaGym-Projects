using FluentValidation;
using OmegaGymServer.Application.Features.Commands.AuthCommand.LoginCommand;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class LoginCommadValidator : AbstractValidator<LoginCommandRequest>
{
    public LoginCommadValidator()
    {
        RuleFor(u => u.Email).EmailAddress().NotNull().WithMessage("{PropertyName} is a valid email address");
        RuleFor(u => u.Password).NotNull().MinimumLength(6).WithMessage("{PropertyName} should at last be {MinLenght} character");
    }
}

