using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.Consts;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.TwoFactorAuthCommand;

public class TwoFactorAuthCommandHandler : IRequestHandler<TwoFactorAuthCommandRequest, TwoFactorAuthCommandResponse>
{

    readonly IAuthService _authService;

    public TwoFactorAuthCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<TwoFactorAuthCommandResponse> Handle(TwoFactorAuthCommandRequest request, CancellationToken cancellationToken)
    {
        bool response = await _authService.TwoFactorAuthAsync(request.Email, request.SingleCode);

        return new()
        {
            Message = response == false ? CommonConstants.TwoFactorHandlerMessageIsFalse : CommonConstants.TwoFactorHandlerMessageIsTrue,
            Status = response
        };
    }
}
