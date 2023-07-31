using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByOperationClaimIdQuery;

public class GetByOperationClaimIdUserQueryRequest : IRequest<GetByOperationClaimIdUserQueryResponse>
{
    public Guid OperationClaimId { get; set; }
}

