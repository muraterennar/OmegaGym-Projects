using MediatR;

namespace OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.DeleteUserSubscriptionCommand;

public class DeleteUserSubscriptionCommandRequest : IRequest<DeleteUserSubscriptionCommandResponse>
{
    public Guid Id { get; set; }
}

