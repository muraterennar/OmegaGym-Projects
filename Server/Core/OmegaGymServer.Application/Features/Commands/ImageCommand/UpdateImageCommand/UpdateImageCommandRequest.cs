using MediatR;

namespace OmegaGymServer.Application.Features.Commands.ImageCommand.UpdateImageCommand;

public class UpdateImageCommandRequest : IRequest<UpdateImageCommandResponse>
{
    public Guid Id { get; set; }
    public string ImageName { get; set; }
    public string ImageUrl { get; set; }
}

