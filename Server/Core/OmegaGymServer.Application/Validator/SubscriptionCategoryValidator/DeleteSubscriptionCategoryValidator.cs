using FluentValidation;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.DeleteSubscriptionCategoryCommand;

namespace OmegaGymServer.Application.Validator.SubscriptionCategoryValidator;

public class DeleteSubscriptionCategoryValidator : AbstractValidator<DeleteSubscriptionCategoryCommandRequest>
{
    public DeleteSubscriptionCategoryValidator()
    {
        RuleFor(sc => sc.Id).NotNull();
    }
}

