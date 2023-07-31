using MediatR;

namespace OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.UpdateUserSubscriptionCommand;

public class UpdateUserSubscriptionCommandRequest : IRequest<UpdateUserSubscriptionCommandResponse>
{
    public Guid Id { get; set; }
    public Guid SubscriptionId { get; set; }
}

