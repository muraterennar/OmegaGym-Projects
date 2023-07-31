using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByIdUserQuery;

public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
{
    readonly IUserReadRepository _userReadRepository;
    readonly IMapper _mapper;

    public GetByIdUserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
    {
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _userReadRepository.GetByIdAsync(request.Id);

        var result = _mapper.Map<GetByIdUserQueryResponse>(model);

        return result;
    }
}

