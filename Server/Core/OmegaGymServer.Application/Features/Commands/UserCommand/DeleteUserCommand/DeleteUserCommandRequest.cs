using MediatR;

namespace OmegaGymServer.Application.Features.Commands.UserCommand.DeleteUserCommand;

public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
{
    public Guid Id { get; set; }
}

