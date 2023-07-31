using FluentValidation;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByUserIdUserSubscription;

namespace OmegaGymServer.Application.Validator.UserSubscriptionValidator;

public class GetByIdUserIdUserSubscriptionQueryValidaiton : AbstractValidator<GetByUserIdUserSubscriptionQueryRequest>
{
    public GetByIdUserIdUserSubscriptionQueryValidaiton()
    {
        RuleFor(us => us.UserId).NotNull();
    }
}

