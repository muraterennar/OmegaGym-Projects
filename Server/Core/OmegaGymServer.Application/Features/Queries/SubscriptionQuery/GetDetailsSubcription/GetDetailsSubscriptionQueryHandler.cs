using AutoMapper;
using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetDetailsSubcription;

public class GetDetailsSubscriptionQueryHandler : IRequestHandler<GetDetailsSubscriptionQueryRequest, List<GetDetailsSubscriptionQueryResponse>>
{
    readonly ISubscriptionService _subscriptionService;
    readonly IMapper _mapper;

    public GetDetailsSubscriptionQueryHandler(ISubscriptionService subscriptionService, IMapper mapper)
    {
        _subscriptionService = subscriptionService;
        _mapper = mapper;
    }

    public async Task<List<GetDetailsSubscriptionQueryResponse>> Handle(GetDetailsSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await _subscriptionService.SubscriptionDetailGetByCategoryNameAsync(request.CategoryName);

        return response.Select(e => new GetDetailsSubscriptionQueryResponse
        {
            Id = e.SubscriptionId,
            SubscriptionCategoryId = e.SubscriptionCategoryId,
            SubscriptionTitle = e.SubscriptionTitle,
            SubscriptionDescription = e.SubscriptionDescription,
            SubscriptionPrice = e.SubscriptionPrice,
            SubscriptionArticlelOne = e.SubscriptionArticlelOne,
            SubscriptionArticlelTwo = e.SubscriptionArticlelTwo,
            SubscriptionArticlelThree = e.SubscriptionArticlelThree,
            CategoryName = e.SubscriptionCategoryName
        }).ToList();
    }
}

