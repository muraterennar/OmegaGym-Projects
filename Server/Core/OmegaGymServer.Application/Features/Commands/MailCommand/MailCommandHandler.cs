using MediatR;
using OmegaGymServer.Application.Abstract.Mail;

namespace OmegaGymServer.Application.Features.Commands.MailCommand;

public class MailCommandHandler : IRequestHandler<MailCommandRequest, MailCommandResponse>
{
    readonly IMailService _mailService;

    public MailCommandHandler(IMailService mailService)
    {
        _mailService = mailService;
    }

    public async Task<MailCommandResponse> Handle(MailCommandRequest request, CancellationToken cancellationToken)
    {

        await _mailService.SendMessageAsync(request.Tos, request.Subject, request.Body, request.IsBodyHtml);
        return new()
        {
            IsSuccess = true,
            Message = "Mail Başarıyla Gönderildi"
        };


    }
}

