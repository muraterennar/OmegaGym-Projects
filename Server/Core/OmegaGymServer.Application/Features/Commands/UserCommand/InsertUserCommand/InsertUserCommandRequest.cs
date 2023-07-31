using MediatR;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Commands.UserCommand.InsertUserCommand;

public class InsertUserCommandRequest : IRequest<InsertUserCommandResponse>
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Gneder { get; set; }

    public Guid? OperationClaimId { get; set; }
}

