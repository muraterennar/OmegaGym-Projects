using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByUserIdUserSubscription;

public class GetByUserIdUserSubscriptionQueryHandler : IRequestHandler<GetByUserIdUserSubscriptionQueryRequest, GetByUserIdUserSubscriptionQueryResponse>
{
    readonly IReadUserSubscriptionRepository _readUserSubscriptionRepository;
    readonly IMapper _mapper;

    public GetByUserIdUserSubscriptionQueryHandler(IReadUserSubscriptionRepository readUserSubscriptionRepository, IMapper mapper)
    {
        _readUserSubscriptionRepository = readUserSubscriptionRepository;
        _mapper = mapper;
    }

    public async Task<GetByUserIdUserSubscriptionQueryResponse> Handle(GetByUserIdUserSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _readUserSubscriptionRepository.GetSingleAsync(us => us.UserId == request.UserId);

        var result = _mapper.Map<GetByUserIdUserSubscriptionQueryResponse>(model);

        return model == null || result == null ? throw new Exception("Searched value not found") : result;
    }
}

