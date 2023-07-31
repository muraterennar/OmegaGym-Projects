using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetAllUserQuery;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, List<GetAllUserQueryResponse>>
{
    readonly IUserReadRepository _userReadRepository;
    readonly IMapper _mapper;

    public GetAllUserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
    {
        _userReadRepository = userReadRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        var model = _userReadRepository.GetAll();

        var result = _mapper.Map<List<GetAllUserQueryResponse>>(model);

        return result.Select(s => new GetAllUserQueryResponse
        {
            Id = s.Id,
            OperationClaimId = s.OperationClaimId,
            FirstName = s.FirstName,
            UserName = s.UserName,
            LastName = s.LastName,
            Email = s.Email,
            Phone = s.Phone,
            CreatedDate = s.CreatedDate,
            UpdatedDate = s.UpdatedDate,
            UserSubscriptionId = s.UserSubscriptionId
        }).ToList();
    }
}

