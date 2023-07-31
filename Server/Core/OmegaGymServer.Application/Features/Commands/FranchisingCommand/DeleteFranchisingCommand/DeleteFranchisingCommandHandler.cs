using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.FranchisingCommand.DeleteFranchisingCommand;

public class DeleteFranchisingCommandHandler : IRequestHandler<DeleteFranchisingCommandRequest, DeleteFranchisingCommandResponse>
{
    readonly IFranchisingService _franchisingService;

    public DeleteFranchisingCommandHandler(IFranchisingService franchisingService)
    {
        _franchisingService = franchisingService;
    }

    public async Task<DeleteFranchisingCommandResponse> Handle(DeleteFranchisingCommandRequest request, CancellationToken cancellationToken)
    {
        await _franchisingService.DeleteAcceptAsync(Guid.Parse(request.Id));
        return new();
    }
}

