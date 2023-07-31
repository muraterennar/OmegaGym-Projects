namespace OmegaGymServer.Application.Features.Commands.AuthCommand.RegisterCommand;

public class RegisterCommandResponse
{
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
}

