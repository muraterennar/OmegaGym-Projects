using MediatR;

namespace OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.InsertUserSubscriptionCommand;

public class InsertUserSubscriptionCommandRequest : IRequest<InsertUserSubscriptionCommandResponse>
{
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }
}

