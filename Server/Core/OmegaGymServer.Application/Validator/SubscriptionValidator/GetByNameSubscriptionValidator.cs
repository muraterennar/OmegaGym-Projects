using System;
using FluentValidation;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByNameSubscriptionCategory;

namespace OmegaGymServer.Application.Validator.SubscriptionValidator
{
    public class GetByNameSubscriptionValidator : AbstractValidator<GetByNameSubscriptionCategoryQueryRequest>
    {
        public GetByNameSubscriptionValidator()
        {
            RuleFor(s => s.SubscriptionCategoryName).NotNull().MinimumLength(3).MaximumLength(50);
        }
    }
}

