using FluentValidation;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByIdForSubscriptionCategory;

namespace OmegaGymServer.Application.Validator.SubscriptionCategoryValidator;

public class GetByIdSubscriptionCateogryValidator : AbstractValidator<GetByIdSubscriptionCategoryQueryRequest>
{
    public GetByIdSubscriptionCateogryValidator()
    {
        RuleFor(sc => sc.Id).NotNull();
    }
}

