using MediatR;

namespace OmegaGymServer.Application.Features.Commands.MailCommand;

public class MailCommandRequest : IRequest<MailCommandResponse>
{
    public string[] Tos { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public bool IsBodyHtml { get; set; }
}

