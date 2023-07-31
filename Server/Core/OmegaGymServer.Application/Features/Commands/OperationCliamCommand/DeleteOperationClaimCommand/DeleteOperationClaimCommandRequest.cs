using MediatR;

namespace OmegaGymServer.Application.Features.Commands.OperationCliamCommand.DeleteOperationClaimCommand;

public class DeleteOperationClaimCommandRequest : IRequest<DeleteOperationClaimCommandResponse>
{
    public Guid Id { get; set; }
}

