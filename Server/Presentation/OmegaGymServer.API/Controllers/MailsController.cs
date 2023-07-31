using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Features.Commands.MailCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OmegaGymServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailsController : ControllerBase
{
    readonly IMediator _mediator;

    public MailsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SendMail(MailCommandRequest mailCommandRequest)
    {
        var response = await _mediator.Send(mailCommandRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }
}

