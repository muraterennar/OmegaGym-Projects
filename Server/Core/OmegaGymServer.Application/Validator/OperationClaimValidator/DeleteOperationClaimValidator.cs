using FluentValidation;
using OmegaGymServer.Application.Features.Commands.OperationCliamCommand.DeleteOperationClaimCommand;

namespace OmegaGymServer.Application.Validator.OperationClaimValidator;

public class DeleteOperationClaimValidator : AbstractValidator<DeleteOperationClaimCommandRequest>
{
    public DeleteOperationClaimValidator()
    {
        RuleFor(op => op.Id).NotNull();
    }
}

