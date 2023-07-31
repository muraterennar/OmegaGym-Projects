using FluentValidation;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByIdUserSubscription;

namespace OmegaGymServer.Application.Validator.UserSubscriptionValidator;

public class GetByIdUserSubscriptionQueryValidaiton : AbstractValidator<GetByIdUserSubscriptionQueryRequest>
{
    public GetByIdUserSubscriptionQueryValidaiton()
    {
        RuleFor(us => us.Id).NotNull();
    }
}

