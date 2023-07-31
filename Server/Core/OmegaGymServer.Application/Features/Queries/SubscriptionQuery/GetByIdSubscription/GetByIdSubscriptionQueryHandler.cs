using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByIdSubscription;

public class GetByIdSubscriptionQueryHandler : IRequestHandler<GetByIdSubscriptionQueryRequest, GetByIdSubscriptionQueryResponse>
{
    readonly ISubscriptionReadRepository _subscriptionReadRepository;
    readonly IMapper _mapper;

    public GetByIdSubscriptionQueryHandler(ISubscriptionReadRepository subscriptionReadRepository, IMapper mapper)
    {
        _subscriptionReadRepository = subscriptionReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdSubscriptionQueryResponse> Handle(GetByIdSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _subscriptionReadRepository.GetByIdAsync(request.Id);

        var result = _mapper.Map<GetByIdSubscriptionQueryResponse>(model);

        return result;
    }
}

