using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByNameSubscription;

public class GetByNameSubscriptionQueryHandler : IRequestHandler<GetByNameSubscriptionQueryRequest, GetByNameSubscriptionQueryResponse>
{
    readonly ISubscriptionReadRepository _subscriptionReadRepository;
    readonly IMapper _mapper;

    public GetByNameSubscriptionQueryHandler(ISubscriptionReadRepository subscriptionReadRepository, IMapper mapper)
    {
        _subscriptionReadRepository = subscriptionReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByNameSubscriptionQueryResponse> Handle(GetByNameSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _subscriptionReadRepository.GetSingleAsync(s => s.SubscriptionTitle == request.SubscriptionTitle);

        var result = _mapper.Map<GetByNameSubscriptionQueryResponse>(model);

        return result;
    }
}

