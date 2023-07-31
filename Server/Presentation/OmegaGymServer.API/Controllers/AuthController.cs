using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Features.Commands.AuthCommand.LoginCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.RegisterCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.ResetTokenCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.SendSingleCodeCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.TwoFactorAuthCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.VerifyResetTokenCommnad;

namespace OmegaGymServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest loginCommandRequest)
        {
            var response = await _mediator.Send(loginCommandRequest);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Regiser([FromBody] RegisterCommandRequest registerCommandRequest)
        {
            var response = await _mediator.Send(registerCommandRequest);
            return Ok(response);
        }

        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordResetAsync([FromBody] ResetTokenCommandRequest resetTokenCommandRequest)
        {
            var response = await _mediator.Send(resetTokenCommandRequest);

            return Ok(response);
        }

        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommnadRequest verifyResetTokenCommnadRequest)
        {
            var response = await _mediator.Send(verifyResetTokenCommnadRequest);
            return Ok(response);
        }

        [HttpPost("send-single-code")]
        public async Task<IActionResult> SendSingleCode([FromBody] SendSingleCodeCommandRequest sendSingleCodeCommandRequest)
        {
            var response = await _mediator.Send(sendSingleCodeCommandRequest);
            return Ok(response);
        }

        [HttpPost("two-factor-auth")]
        public async Task<IActionResult> TwoFactorAuth([FromBody] TwoFactorAuthCommandRequest twoFactorAuthCommandRequest)
        {
            var response = await _mediator.Send(twoFactorAuthCommandRequest);
            return Ok(response);
        }
    }
}

