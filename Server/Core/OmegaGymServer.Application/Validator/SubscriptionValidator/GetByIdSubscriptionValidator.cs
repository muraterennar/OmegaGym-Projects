using FluentValidation;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByIdSubscription;

namespace OmegaGymServer.Application.Validator.SubscriptionValidator;

public class GetByIdSubscriptionValidator : AbstractValidator<GetByIdSubscriptionQueryRequest>
{
    public GetByIdSubscriptionValidator()
    {
        RuleFor(s => s.Id).NotNull();
    }
}

