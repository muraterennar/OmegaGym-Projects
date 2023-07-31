using MediatR;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCommand.DeleteSubscriptionCommand;

public class DeleteSubscriptionCommandRequest : IRequest<DeleteSubscriptionCommandResponse>
{
    public Guid Id { get; set; }
}

