using System.Collections.Generic;
using AutoMapper;
using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetAllSubscriptionCategory;

public class GetAllSubscriptionCategoryQueryHandler : IRequestHandler<GetAllSubscriptionCategoryQueryRequest, List<GetAllSubscriptionCategoryQueryResponse>>
{
    readonly ISubscriptionCategoryService _subscriptionCategoryService;

    public GetAllSubscriptionCategoryQueryHandler(ISubscriptionCategoryService subscriptionCategoryService)
    {
        _subscriptionCategoryService = subscriptionCategoryService;
    }

    public async Task<List<GetAllSubscriptionCategoryQueryResponse>> Handle(GetAllSubscriptionCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        var model = _subscriptionCategoryService.SubscriptionCategoryGetAll();

        return model.Select(s => new GetAllSubscriptionCategoryQueryResponse
        {
            Id = s.Id,
            SubscriptionCategoryName = s.CategoryName
        }).ToList();
    }
}

