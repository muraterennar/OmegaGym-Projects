using MediatR;

namespace OmegaGymServer.Application.Features.Commands.OperationCliamCommand.InsertOperationClaimCommand;

public class InsertOperationCliamCommandRequest : IRequest<InsertOperationCliamCommandResponse>
{
    public string RoleName { get; set; }
}

