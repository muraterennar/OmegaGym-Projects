using FluentValidation;
using OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.UpdateUserSubscriptionCommand;

namespace OmegaGymServer.Application.Validator.UserSubscriptionValidator;

public class UpdateSubscriptionCommandValidaiton : AbstractValidator<UpdateUserSubscriptionCommandRequest>
{
    public UpdateSubscriptionCommandValidaiton()
    {
        RuleFor(us => us.Id).NotNull();
        RuleFor(us => us.SubscriptionId).NotNull();
    }
}

