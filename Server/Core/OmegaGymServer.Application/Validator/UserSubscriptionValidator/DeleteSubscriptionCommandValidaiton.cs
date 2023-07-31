using FluentValidation;
using OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.DeleteUserSubscriptionCommand;

namespace OmegaGymServer.Application.Validator.UserSubscriptionValidator;

public class DeleteSubscriptionCommandValidaiton : AbstractValidator<DeleteUserSubscriptionCommandRequest>
{
    public DeleteSubscriptionCommandValidaiton()
    {
        RuleFor(us => us.Id).NotNull();
    }
}