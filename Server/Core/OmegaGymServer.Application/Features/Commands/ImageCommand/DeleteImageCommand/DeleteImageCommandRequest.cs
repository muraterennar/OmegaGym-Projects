using MediatR;

namespace OmegaGymServer.Application.Features.Commands.ImageCommand.DeleteImageCommand;

public class DeleteImageCommandRequest : IRequest<DeleteImageCommandResponse>
{
    public Guid Id { get; set; }
}

