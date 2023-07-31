using MediatR;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.VerifyResetTokenCommnad
{
    public class VerifyResetTokenCommnadRequest : IRequest<VerifyResetTokenCommnadResponse>
    {
        public string UserId { get; set; }
        public string ResetToken { get; set; }
    }
}