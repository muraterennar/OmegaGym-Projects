using OmegaGymServer.Application.DTOs.AuthDTOs;
using OmegaGymServer.Application.Features.Commands.AuthCommand.LoginCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.RegisterCommand;

namespace OmegaGymServer.Application.Abstract.Services;

public interface IAuthService
{
    Task<LoginCommandResponse> LoginAsync(LoginDTO loginDTO);
    Task<RegisterCommandResponse> RegisterAsync(RegisterDTO registerDTO);
    // ========== Reset Password ==========
    Task ResetPasswordSendEmailAsync(string email);
    Task<bool> VerifyPasswordTokenAsync(string userId, string resetToken);

    // ========== Two Factor Auth ==========
    Task<string> SendSingleCodeAsync(string email);
    Task<bool> TwoFactorAuthAsync(string email, string singleCode);
}

