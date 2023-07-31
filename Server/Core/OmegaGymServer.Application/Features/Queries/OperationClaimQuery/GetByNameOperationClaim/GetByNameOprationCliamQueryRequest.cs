using MediatR;

namespace OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByNameOperationClaim;

public class GetByNameOprationCliamQueryRequest : IRequest<GetByNameOprationCliamQueryResponse>
{
    public string RoleName { get; set; }
}

