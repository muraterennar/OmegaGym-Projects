using MediatR;

namespace OmegaGymServer.Application.Features.Commands.UserCommand.UpdatePasswordCommand
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        public string UserId { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
        public string PasswordConfirm { get; set; }
    }
}