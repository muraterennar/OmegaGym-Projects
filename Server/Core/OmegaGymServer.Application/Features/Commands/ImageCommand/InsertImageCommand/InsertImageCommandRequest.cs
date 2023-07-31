using MediatR;

namespace OmegaGymServer.Application.Features.Commands.ImageCommand.InsertImageCommand
{
    public class InsertImageCommandRequest : IRequest<InsertImageCommandResponse>
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}

