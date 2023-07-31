using MediatR;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.LoginCommand;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

