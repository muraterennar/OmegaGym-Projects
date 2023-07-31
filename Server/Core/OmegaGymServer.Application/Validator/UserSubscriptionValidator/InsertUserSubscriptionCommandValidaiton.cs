using System;
using FluentValidation;
using OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.InsertUserSubscriptionCommand;

namespace OmegaGymServer.Application.Validator.UserSubscriptionValidator
{
    public class InsertUserSubscriptionCommandValidaiton : AbstractValidator<InsertUserSubscriptionCommandRequest>
    {
        public InsertUserSubscriptionCommandValidaiton()
        {
            RuleFor(us => us.SubscriptionId).NotNull();
            RuleFor(us => us.UserId).NotNull();
        }
    }
}

