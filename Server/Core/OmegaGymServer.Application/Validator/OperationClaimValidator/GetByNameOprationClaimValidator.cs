using FluentValidation;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByNameOperationClaim;

namespace OmegaGymServer.Application.Validator.OperationClaimValidator;

public class GetByNameOprationClaimValidator : AbstractValidator<GetByNameOprationCliamQueryRequest>
{
    public GetByNameOprationClaimValidator()
    {
        RuleFor(op => op.RoleName).NotNull();
        RuleFor(op => op.RoleName).MinimumLength(4).MaximumLength(50);
    }
}

