using MediatR;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.SendSingleCodeCommand;

public class SendSingleCodeCommandRequest : IRequest<SendSingleCodeCommandResponse>
{
    public string Email { get; set; }
}