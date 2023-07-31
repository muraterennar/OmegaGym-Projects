namespace OmegaGymServer.Application.Features.Commands.AuthCommand.LoginCommand;

public class LoginCommandResponse
{
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
}

