using AutoMapper;
using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByIdForSubscriptionCategory;

public class GetByIdSubscriptionCategoryQueryHandler : IRequestHandler<GetByIdSubscriptionCategoryQueryRequest, GetByIdSubscriptionCategoryQueryResponse>
{

    readonly ISubscriptionCategoryService _subscriptionCategoryService;

    public GetByIdSubscriptionCategoryQueryHandler(ISubscriptionCategoryService subscriptionCategoryService)
    {
        _subscriptionCategoryService = subscriptionCategoryService;
    }

    public async Task<GetByIdSubscriptionCategoryQueryResponse> Handle(GetByIdSubscriptionCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _subscriptionCategoryService.SubscriptionCategoryGetByIdAsync(request.Id);

        return new()
        {
            Id = model.Id,
            SubscriptionCategoryName = model.CategoryName
        };
    }
}

