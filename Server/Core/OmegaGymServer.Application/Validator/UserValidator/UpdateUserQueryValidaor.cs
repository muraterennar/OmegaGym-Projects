using FluentValidation;
using OmegaGymServer.Application.Features.Commands.UserCommand.UpdateUserCommand;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class UpdateUserQueryValidaor : AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserQueryValidaor()
    {
        RuleFor(u => u.Id).NotNull();
        RuleFor(u => u.FirstName).MinimumLength(4).MaximumLength(50);
        RuleFor(u => u.LastName).MinimumLength(4).MaximumLength(50);
        RuleFor(u => u.UserName).MinimumLength(4).MaximumLength(50);
        RuleFor(u => u.Email).MaximumLength(50).EmailAddress();
        RuleFor(u => u.Phone).MaximumLength(11).MinimumLength(11);
    }
}

