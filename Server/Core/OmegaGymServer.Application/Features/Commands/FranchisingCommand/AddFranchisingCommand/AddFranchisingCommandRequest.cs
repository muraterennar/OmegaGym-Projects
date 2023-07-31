using MediatR;

namespace OmegaGymServer.Application.Features.Commands.FranchisingCommand.AddFranchisingCommand;

public class AddFranchisingCommandRequest : IRequest<AddFranchisingCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}