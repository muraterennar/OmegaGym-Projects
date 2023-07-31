using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByUsernameUserQuery;

public class GetByUsernameUserQueryHandler : IRequestHandler<GetByUsernameUserQueryRequest, GetByUsernameUserQueryResponse>
{
    readonly IUserReadRepository _userReadRepository;
    readonly IMapper _mapper;

    public GetByUsernameUserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
    {
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByUsernameUserQueryResponse> Handle(GetByUsernameUserQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _userReadRepository.GetSingleAsync(u => u.UserName == request.UserName);

        var result = _mapper.Map<GetByUsernameUserQueryResponse>(model);

        return result == null || model == null ? throw new Exception("Searched value not found") : result;
    }
}

