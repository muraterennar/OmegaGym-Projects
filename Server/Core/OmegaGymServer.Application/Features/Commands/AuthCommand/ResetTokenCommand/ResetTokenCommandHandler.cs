using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.ResetTokenCommand;

public class ResetTokenCommandHandler : IRequestHandler<ResetTokenCommandRequest, ResetTokenCommandResponse>
{
    readonly IAuthService _authService;

    public ResetTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ResetTokenCommandResponse> Handle(ResetTokenCommandRequest request, CancellationToken cancellationToken)
    {
        await _authService.ResetPasswordSendEmailAsync(request.Email);

        return new();
    }
}

