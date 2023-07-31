using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByFirstnameUserQuery;

public class GetByFirstnameUserQueryHandler : IRequestHandler<GetByFirstnameUserQueryRequest, GetByFirstnameUserQueryResponse>
{
    readonly IUserReadRepository _userReadRepository;
    readonly IMapper _mapper;

    public GetByFirstnameUserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
    {
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByFirstnameUserQueryResponse> Handle(GetByFirstnameUserQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _userReadRepository.GetSingleAsync(u => u.FirstName == request.FirstName);

        var result = _mapper.Map<GetByFirstnameUserQueryResponse>(model);

        return result;
    }
}

