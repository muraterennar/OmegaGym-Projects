using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.SendSingleCodeCommand;

public class SendSingleCodeCommandHandler : IRequestHandler<SendSingleCodeCommandRequest, SendSingleCodeCommandResponse>
{
    readonly IAuthService _authService;

    public SendSingleCodeCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<SendSingleCodeCommandResponse> Handle(SendSingleCodeCommandRequest request, CancellationToken cancellationToken)
    {
        await _authService.SendSingleCodeAsync(request.Email);

        return new()
        {
            Message = "Başarıyla Doğrulandı",
            Status = true
        };
    }
}

