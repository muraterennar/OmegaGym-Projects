using FluentValidation;
using OmegaGymServer.Application.Features.Commands.SubscriptionCommand.UpdateSubscriptionCommand;

namespace OmegaGymServer.Application.Validator.SubscriptionValidator;

public class UpdateSubscriptionValidator : AbstractValidator<UpdateSubscriptionCommandRequest>
{
    public UpdateSubscriptionValidator()
    {
        RuleFor(s => s.Id).NotNull();
        RuleFor(s => s.SubscriptionTitle).NotNull().MinimumLength(3).MaximumLength(20);
        RuleFor(s => s.SubscriptionPrice).NotNull();
        RuleFor(s => s.SubscriptionCategoryId).NotNull();
        RuleFor(s => s.SubscriptionDescription).NotNull().MinimumLength(4).MaximumLength(250);
        RuleFor(s => s.SubscriptionArticlelOne).NotNull().MinimumLength(4).MaximumLength(200);
        RuleFor(s => s.SubscriptionArticlelTwo).NotNull().MinimumLength(4).MaximumLength(200);
        RuleFor(s => s.SubscriptionArticlelThree).NotNull().MinimumLength(4).MaximumLength(200);
    }
}

