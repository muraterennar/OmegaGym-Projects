using MediatR;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.ResetTokenCommand;

public class ResetTokenCommandRequest : IRequest<ResetTokenCommandResponse>
{
    public string Email { get; set; }
}