using MediatR;

namespace OmegaGymServer.Application.Features.Commands.FranchisingCommand.DeleteFranchisingCommand;

public class DeleteFranchisingCommandRequest : IRequest<DeleteFranchisingCommandResponse>
{
    public string Id { get; set; }
}