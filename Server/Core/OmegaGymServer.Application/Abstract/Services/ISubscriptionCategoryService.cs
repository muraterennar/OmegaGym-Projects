using OmegaGymServer.Application.DTOs.SubscriptionCategoryDTOs;

namespace OmegaGymServer.Application.Abstract.Services;

public interface ISubscriptionCategoryService
{
    List<SubscriptionCategoryDTO> SubscriptionCategoryGetAll();
    Task<SubscriptionCategoryDTO> SubscriptionCategoryGetByIdAsync(Guid id);
    Task<SubscriptionCategoryDTO> SubscriptionCategoryGetByNameAsync(string categoryName);
}

