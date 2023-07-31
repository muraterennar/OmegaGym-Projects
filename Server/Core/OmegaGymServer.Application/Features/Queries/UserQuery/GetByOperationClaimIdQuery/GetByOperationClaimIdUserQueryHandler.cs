using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByOperationClaimIdQuery;

public class GetByOperationClaimIdUserQueryHandler : IRequestHandler<GetByOperationClaimIdUserQueryRequest, GetByOperationClaimIdUserQueryResponse>
{
    readonly IUserReadRepository _userReadRepository;
    readonly IMapper _mapper;

    public GetByOperationClaimIdUserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
    {
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByOperationClaimIdUserQueryResponse> Handle(GetByOperationClaimIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _userReadRepository.GetSingleAsync(u => u.OperationClaimId == request.OperationClaimId);

        var result = _mapper.Map<GetByOperationClaimIdUserQueryResponse>(model);

        return result;
    }
}

