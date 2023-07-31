using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.FranchisingCommand.AddFranchisingCommand;

public class AddFranchisingCommandHandler : IRequestHandler<AddFranchisingCommandRequest, AddFranchisingCommandResponse>
{
    readonly IFranchisingService _franchisingService;

    public AddFranchisingCommandHandler(IFranchisingService franchisingService)
    {
        _franchisingService = franchisingService;
    }

    public async Task<AddFranchisingCommandResponse> Handle(AddFranchisingCommandRequest request, CancellationToken cancellationToken)
    {
        await _franchisingService.AcceptAsync(new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phono = request.Phone
        });

        return new();
    }
}