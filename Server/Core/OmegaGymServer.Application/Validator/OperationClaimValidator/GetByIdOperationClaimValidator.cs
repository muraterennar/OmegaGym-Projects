using FluentValidation;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByIdOperationClaim;

namespace OmegaGymServer.Application.Validator.OperationClaimValidator
{
    public class GetByIdOperationClaimValidator : AbstractValidator<GetByIdOperationClaimQueryRequest>
    {
        public GetByIdOperationClaimValidator()
        {
            RuleFor(o => o.Id).NotNull();
        }
    }
}

