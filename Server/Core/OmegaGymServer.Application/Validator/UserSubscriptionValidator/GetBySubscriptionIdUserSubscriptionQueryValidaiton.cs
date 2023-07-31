using FluentValidation;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetBySubscriptionIdUserSubscription;

namespace OmegaGymServer.Application.Validator.UserSubscriptionValidator;

public class GetBySubscriptionIdUserSubscriptionQueryValidaiton : AbstractValidator<GetBySubscriptionIdUserSubscriptionQueryRequest>
{
    public GetBySubscriptionIdUserSubscriptionQueryValidaiton()
    {
        RuleFor(us => us.SubscriptionId).NotNull();
    }
}

