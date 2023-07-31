using FluentValidation;
using OmegaGymServer.Application.Features.Commands.OperationCliamCommand.UpdateOperationCliamCommand;

namespace OmegaGymServer.Application.Validator.OperationClaimValidator;

public class UpdateOperationClaimValidator : AbstractValidator<UpdateOperationClaimCommandRequest>
{
    public UpdateOperationClaimValidator()
    {
        RuleFor(op => op.Id).NotNull();
        RuleFor(op => op.RoleName).NotNull().MinimumLength(3).MaximumLength(12);
    }
}

