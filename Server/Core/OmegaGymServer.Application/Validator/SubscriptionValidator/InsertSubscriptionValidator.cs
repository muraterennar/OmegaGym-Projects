using FluentValidation;
using OmegaGymServer.Application.Features.Commands.SubscriptionCommand.InsertSubscriptionCommand;

namespace OmegaGymServer.Application.Validator.SubscriptionValidator
{
    public class InsertSubscriptionValidator : AbstractValidator<InsertSubscriptionCommandRequest>
    {
        public InsertSubscriptionValidator()
        {
            RuleFor(s => s.SubscriptionTitle).NotNull();
            RuleFor(s => s.SubscriptionTitle).MinimumLength(4).MaximumLength(150);

            RuleFor(s => s.SubscriptionDescription).NotNull();
            RuleFor(s => s.SubscriptionDescription).MinimumLength(4).MaximumLength(200);

            RuleFor(s => s.SubscriptionArticlelOne).NotNull();
            RuleFor(s => s.SubscriptionArticlelOne).MinimumLength(4).MaximumLength(200);

            RuleFor(s => s.SubscriptionArticlelTwo).NotNull();
            RuleFor(s => s.SubscriptionArticlelTwo).MinimumLength(4).MaximumLength(200);

            RuleFor(s => s.SubscriptionArticlelThree).NotNull();
            RuleFor(s => s.SubscriptionArticlelThree).MinimumLength(4).MaximumLength(200);

            RuleFor(s => s.SubscriptionPrice).NotNull();

            RuleFor(s => s.SubscriptionCategoryId).NotNull();

        }
    }
}

