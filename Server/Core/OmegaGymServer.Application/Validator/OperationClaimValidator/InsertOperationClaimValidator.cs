using FluentValidation;
using OmegaGymServer.Application.Features.Commands.OperationCliamCommand.InsertOperationClaimCommand;

namespace OmegaGymServer.Application.Validator.OperationClaimValidator;

public class InsertOperationClaimValidator : AbstractValidator<InsertOperationCliamCommandRequest>
{
    public InsertOperationClaimValidator()
    {
        RuleFor(op => op.RoleName).NotNull().MinimumLength(3).MaximumLength(12);
    }
}

