using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetAllSubscription;

public class GetAllSubscriptionQueryHandler : IRequestHandler<GetAllSubscriptionQueryRequest, List<GetAllSubscriptionQueryResponse>>
{
    readonly ISubscriptionReadRepository _subscriptionReadRepository;

    public GetAllSubscriptionQueryHandler(ISubscriptionReadRepository subscriptionReadRepository)
    {
        _subscriptionReadRepository = subscriptionReadRepository;
    }

    public async Task<List<GetAllSubscriptionQueryResponse>> Handle(GetAllSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var model = _subscriptionReadRepository.GetAll();

        return model.Select(s => new GetAllSubscriptionQueryResponse
        {
            Id = s.Id,
            SubscriptionTitle = s.SubscriptionTitle,
            SubscriptionPrice = s.SubscriptionPrice,
            SubscriptionDescription = s.SubscriptionDescription,
            SubscriptionArticlelOne = s.SubscriptionArticlelOne,
            SubscriptionArticlelTwo = s.SubscriptionArticlelTwo,
            SubscriptionArticlelThree = s.SubscriptionArticlelThree,
            SubscriptionCategoryId = s.SubscriptionCategoryId
        }).ToList();
    }
}

