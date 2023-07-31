using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.SubscriptionCategoryDTOs;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;

namespace OmegaGymServer.Persistence.Services;

public class SubscriptionCategoryService : ISubscriptionCategoryService
{
    readonly ISubscriptionCategoryReadRepository _subscriptionCategoryReadRepository;
    readonly ISubscriptionCategoryWriteRepository _subscriptionCategoryWriteRepository;

    public SubscriptionCategoryService(ISubscriptionCategoryReadRepository subscriptionCategoryReadRepository, ISubscriptionCategoryWriteRepository subscriptionCategoryWriteRepository)
    {
        _subscriptionCategoryReadRepository = subscriptionCategoryReadRepository;
        _subscriptionCategoryWriteRepository = subscriptionCategoryWriteRepository;
    }

    public List<SubscriptionCategoryDTO> SubscriptionCategoryGetAll()
    {
        var models = _subscriptionCategoryReadRepository.GetAll();

        return models.Select(e => new SubscriptionCategoryDTO
        {
            Id = e.Id,
            CategoryName = e.SubscriptionCategoryName
        }).ToList();
    }

    public async Task<SubscriptionCategoryDTO> SubscriptionCategoryGetByIdAsync(Guid id)
    {
        var model = await _subscriptionCategoryReadRepository.GetByIdAsync(id);
        return new()
        {
            Id = model.Id,
            CategoryName = model.SubscriptionCategoryName
        };
    }

    public async Task<SubscriptionCategoryDTO> SubscriptionCategoryGetByNameAsync(string categoryName)
    {
        var model = await _subscriptionCategoryReadRepository.GetSingleAsync(c => c.SubscriptionCategoryName == categoryName);
        return new()
        {
            Id = model.Id,
            CategoryName = model.SubscriptionCategoryName
        };
    }
}

