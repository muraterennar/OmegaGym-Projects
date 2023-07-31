using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.SubscriptionDTOs;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;

namespace OmegaGymServer.Persistence.Services;

public class SubscriptionService : ISubscriptionService
{
    readonly ISubscriptionReadRepository _subscriptionReadRepository;
    readonly ISubscriptionWriteRepository _subscriptionWriteRepository;
    readonly ISubscriptionCategoryService _subscriptionCategoryService;

    public SubscriptionService(ISubscriptionReadRepository subscriptionReadRepository, ISubscriptionWriteRepository subscriptionWriteRepository, ISubscriptionCategoryService subscriptionCategoryService)
    {
        _subscriptionReadRepository = subscriptionReadRepository;
        _subscriptionWriteRepository = subscriptionWriteRepository;
        _subscriptionCategoryService = subscriptionCategoryService;
    }

    public List<SubscriptionDTO> SubscriptionGetAll()
    {
        var models = _subscriptionReadRepository.GetAll();
        return models.Select(x => new SubscriptionDTO
        {
            Id = x.Id,
            SubscriptionCategoryId = x.SubscriptionCategoryId,
            SubscriptionTitle = x.SubscriptionTitle,
            SubscriptionDescription = x.SubscriptionDescription,
            SubscriptionPrice = x.SubscriptionPrice,
            SubscriptionArticlelOne = x.SubscriptionArticlelOne,
            SubscriptionArticlelTwo = x.SubscriptionArticlelTwo,
            SubscriptionArticlelThree = x.SubscriptionArticlelThree
        }).ToList();
    }

    public async Task<SubscriptionDTO> SubscriptionGetByIdAsync(Guid id)
    {
        var model = await _subscriptionReadRepository.GetByIdAsync(id);
        return new()
        {
            Id = model.Id,
            SubscriptionCategoryId = model.SubscriptionCategoryId,
            SubscriptionTitle = model.SubscriptionTitle,
            SubscriptionDescription = model.SubscriptionDescription,
            SubscriptionPrice = model.SubscriptionPrice,
            SubscriptionArticlelOne = model.SubscriptionArticlelOne,
            SubscriptionArticlelTwo = model.SubscriptionArticlelTwo,
            SubscriptionArticlelThree = model.SubscriptionArticlelThree
        };
    }

    public async Task<List<SubscriptionDetailDTO>> SubscriptionDetailGetByCategoryNameAsync(string categoryName)
    {

        //Category gaetirilecke name göre
        var category = await _subscriptionCategoryService.SubscriptionCategoryGetByNameAsync(categoryName);

        //category ıd ile subscriptionslar getirilecek (birden çok)
        var getBySubscriptionCategoryId = _subscriptionReadRepository.GetWhere(x => x.SubscriptionCategoryId == category.Id);

        //Veriyi İşleme
        return getBySubscriptionCategoryId.Select(x => new SubscriptionDetailDTO
        {
            SubscriptionId = x.Id,
            SubscriptionCategoryId = x.SubscriptionCategoryId,
            SubscriptionCategoryName = category.CategoryName,
            SubscriptionTitle = x.SubscriptionTitle,
            SubscriptionDescription = x.SubscriptionDescription,
            SubscriptionPrice = x.SubscriptionPrice,
            SubscriptionArticlelOne = x.SubscriptionArticlelOne,
            SubscriptionArticlelTwo = x.SubscriptionArticlelTwo,
            SubscriptionArticlelThree = x.SubscriptionArticlelThree
        }).ToList();
    }
}

