using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.UserCommand.UpdatePasswordCommand;

public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
{
    readonly IUserService _userService;
    readonly IAuthService _authService;

    public UpdatePasswordCommandHandler(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
    {


        if (!request.NewPassword.Equals(request.PasswordConfirm))
            throw new PasswordChanceFailedException("Şifre Doğrulama Hatası !");


        bool state = await _userService.UpdatePassword(new()
        {
            NewPassword = request.NewPassword,
            ResetToken = request.ResetToken,
            UserId = request.UserId
        });

        return new()
        {
            State = state
        };
    }
}

