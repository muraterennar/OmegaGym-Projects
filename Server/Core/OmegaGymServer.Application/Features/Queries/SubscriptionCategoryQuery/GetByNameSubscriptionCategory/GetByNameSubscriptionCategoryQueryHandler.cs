using AutoMapper;
using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByNameSubscriptionCategory;

public class GetByNameSubscriptionCategoryQueryHandler : IRequestHandler<GetByNameSubscriptionCategoryQueryRequest, GetByNameSubscriptionCategoryQueryResponse>
{
    readonly ISubscriptionCategoryService _subscriptionCategoryService;

    public GetByNameSubscriptionCategoryQueryHandler(ISubscriptionCategoryService subscriptionCategoryService)
    {
        _subscriptionCategoryService = subscriptionCategoryService;
    }

    public async Task<GetByNameSubscriptionCategoryQueryResponse> Handle(GetByNameSubscriptionCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _subscriptionCategoryService.SubscriptionCategoryGetByNameAsync(request.SubscriptionCategoryName);

        return new()
        {
            Id = model.Id,
            SubscriptionCategoryName = model.CategoryName
        };

    }
}

