using FluentValidation;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.UpdateSubscriptionCategoryCommand;

namespace OmegaGymServer.Application.Validator.SubscriptionCategoryValidator;

public class UpdateSubscriptionCategoryValidator : AbstractValidator<UpdateSubscriptionCategoryCommandRequest>
{
    public UpdateSubscriptionCategoryValidator()
    {
        RuleFor(sc => sc.Id).NotNull();
        RuleFor(sc => sc.SubscriptionCategoryName).NotNull().MinimumLength(3).MaximumLength(50);
    }
}

