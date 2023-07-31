using FluentValidation;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.InsertSubscriptionCategoryCommand;

namespace OmegaGymServer.Application.Validator.SubscriptionCategoryValidator;

public class InsertSubscriptionCategoryValidator : AbstractValidator<InsertSubscriptionCategoryQueryRequest>
{
    public InsertSubscriptionCategoryValidator()
    {
        RuleFor(sc => sc.SubscriptionCategoryName).NotNull();
        RuleFor(sc => sc.SubscriptionCategoryName).MinimumLength(3).MaximumLength(50);
    }
}

