using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;

namespace OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByIdOperationClaim;

public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQueryRequest, GetByIdOperationClaimQueryResponse>
{
    readonly IOperationClaimReadRepository _operationClaimReadRepository;
    readonly IMapper _mapper;

    public GetByIdOperationClaimQueryHandler(IOperationClaimReadRepository operationClaimReadRepository, IMapper mapper)
    {
        _operationClaimReadRepository = operationClaimReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdOperationClaimQueryResponse> Handle(GetByIdOperationClaimQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _operationClaimReadRepository.GetByIdAsync(request.Id);

        var result = _mapper.Map<GetByIdOperationClaimQueryResponse>(model);

        return result;
    }
}

