using AutoMapper;
using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;

namespace OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByNameOperationClaim;

public class GetByNameOprationCliamQueryHandler : IRequestHandler<GetByNameOprationCliamQueryRequest, GetByNameOprationCliamQueryResponse>
{
    readonly IOperationClaimService _operationClaimService;

    public GetByNameOprationCliamQueryHandler(IOperationClaimService operationClaimService)
    {
        _operationClaimService = operationClaimService;
    }

    public async Task<GetByNameOprationCliamQueryResponse> Handle(GetByNameOprationCliamQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await _operationClaimService.GetByNameOprationClaimAsync(request.RoleName);

        return new()
        {
            Id = response.Id,
            RoleName = response.RoleName
        };
    }
}

