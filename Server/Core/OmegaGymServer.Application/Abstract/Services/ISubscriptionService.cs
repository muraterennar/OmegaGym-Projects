using OmegaGymServer.Application.DTOs.SubscriptionDTOs;

namespace OmegaGymServer.Application.Abstract.Services;

public interface ISubscriptionService
{
    List<SubscriptionDTO> SubscriptionGetAll();
    Task<SubscriptionDTO> SubscriptionGetByIdAsync(Guid id);

    Task<List<SubscriptionDetailDTO>> SubscriptionDetailGetByCategoryNameAsync(string categoryName);
}

