using FluentValidation;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByNameSubscriptionCategory;

namespace OmegaGymServer.Application.Validator.SubscriptionCategoryValidator;

public class GetByNameSubscriptionCategoryValidator : AbstractValidator<GetByNameSubscriptionCategoryQueryRequest>
{
    public GetByNameSubscriptionCategoryValidator()
    {
        RuleFor(sc => sc.SubscriptionCategoryName).NotNull();
        RuleFor(sc => sc.SubscriptionCategoryName).MinimumLength(3).MaximumLength(50);
    }
}

