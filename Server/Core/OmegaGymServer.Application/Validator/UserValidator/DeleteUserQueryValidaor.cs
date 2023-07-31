using FluentValidation;
using OmegaGymServer.Application.Features.Commands.UserCommand.DeleteUserCommand;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class DeleteUserQueryValidaor : AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserQueryValidaor()
    {
        RuleFor(u => u.Id).NotNull();
    }
}

