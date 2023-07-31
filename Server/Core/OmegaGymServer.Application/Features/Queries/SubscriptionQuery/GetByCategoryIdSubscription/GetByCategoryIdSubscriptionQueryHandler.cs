using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByCategoryIdSubscription;

public class GetByCategoryIdSubscriptionQueryHandler : IRequestHandler<GetByCategoryIdSubscriptionQueryRequest, GetByCategoryIdSubscriptionQueryReponse>
{
    readonly ISubscriptionReadRepository _subscriptionReadRepository;
    readonly IMapper _mapper;

    public GetByCategoryIdSubscriptionQueryHandler(ISubscriptionReadRepository subscriptionReadRepository, IMapper mapper)
    {
        _subscriptionReadRepository = subscriptionReadRepository;
        _mapper = mapper;
    }

    public async Task<GetByCategoryIdSubscriptionQueryReponse> Handle(GetByCategoryIdSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _subscriptionReadRepository.GetSingleAsync(s => s.SubscriptionCategoryId == request.SubscriptionCategoryId);

        var result = _mapper.Map<GetByCategoryIdSubscriptionQueryReponse>(model);

        return result;
    }
}

