using FluentValidation;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByCategoryIdSubscription;

namespace OmegaGymServer.Application.Validator.SubscriptionValidator;

public class GetByCategoryIdSubscriptionValidator : AbstractValidator<GetByCategoryIdSubscriptionQueryRequest>
{
    public GetByCategoryIdSubscriptionValidator()
    {
        RuleFor(s => s.SubscriptionCategoryId).NotNull();
    }
}

