using FluentValidation;
using OmegaGymServer.Application.Features.Commands.UserCommand.InsertUserCommand;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class InsertUserCommandValidaor : AbstractValidator<InsertUserCommandRequest>
{
    public InsertUserCommandValidaor()
    {
        RuleFor(u => u.FirstName).NotNull().MinimumLength(4).MaximumLength(50);
        RuleFor(u => u.LastName).NotNull().MinimumLength(4).MaximumLength(50);
        RuleFor(u => u.UserName).NotNull().MinimumLength(4).MaximumLength(50);
        RuleFor(u => u.Email).NotNull().EmailAddress().MaximumLength(50);
        RuleFor(u => u.Phone).MinimumLength(10).MaximumLength(11);
    }
}

