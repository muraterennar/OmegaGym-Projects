using System;
using MediatR;

namespace OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByIdOperationClaim;

public class GetByIdOperationClaimQueryRequest : IRequest<GetByIdOperationClaimQueryResponse>
{
    public Guid Id { get; set; }
}

