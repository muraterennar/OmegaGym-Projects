using MediatR;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.TwoFactorAuthCommand;

public class TwoFactorAuthCommandRequest : IRequest<TwoFactorAuthCommandResponse>
{
    public string Email { get; set; }
    public string SingleCode { get; set; }
}