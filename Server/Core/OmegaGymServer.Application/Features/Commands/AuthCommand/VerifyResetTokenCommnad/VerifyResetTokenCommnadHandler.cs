using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.VerifyResetTokenCommnad;

public class VerifyResetTokenCommnadHandler : IRequestHandler<VerifyResetTokenCommnadRequest, VerifyResetTokenCommnadResponse>
{
    readonly IAuthService _authService;

    public VerifyResetTokenCommnadHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<VerifyResetTokenCommnadResponse> Handle(VerifyResetTokenCommnadRequest request, CancellationToken cancellationToken)
    {
        bool response = await _authService.VerifyPasswordTokenAsync(request.UserId, request.ResetToken);


        return new()
        {
            State = response
        };
    }
}

