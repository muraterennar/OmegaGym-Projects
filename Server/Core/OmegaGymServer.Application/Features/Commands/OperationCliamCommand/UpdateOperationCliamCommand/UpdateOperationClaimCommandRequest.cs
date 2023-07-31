using MediatR;

namespace OmegaGymServer.Application.Features.Commands.OperationCliamCommand.UpdateOperationCliamCommand;

public class UpdateOperationClaimCommandRequest : IRequest<UpdateOperationClaimCommandResponse>
{
    public Guid Id { get; set; }
    public string RoleName { get; set; }
}

