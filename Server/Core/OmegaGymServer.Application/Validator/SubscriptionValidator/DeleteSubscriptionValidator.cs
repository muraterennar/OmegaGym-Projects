using FluentValidation;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.DeleteSubscriptionCategoryCommand;

namespace OmegaGymServer.Application.Validator.SubscriptionValidator;

public class DeleteSubscriptionValidator : AbstractValidator<DeleteSubscriptionCategoryCommandRequest>
{
    public DeleteSubscriptionValidator()
    {
        RuleFor(s => s.Id).NotNull();
    }
}

