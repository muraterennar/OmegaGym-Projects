using FluentValidation;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByOperationClaimIdQuery;

namespace OmegaGymServer.Application.Validator.UserValidator;

public class GetByOperationClaimIdUserQueryValidaor : AbstractValidator<GetByOperationClaimIdUserQueryRequest>
{
    public GetByOperationClaimIdUserQueryValidaor()
    {
        RuleFor(u => u.OperationClaimId).NotNull();
    }
}

