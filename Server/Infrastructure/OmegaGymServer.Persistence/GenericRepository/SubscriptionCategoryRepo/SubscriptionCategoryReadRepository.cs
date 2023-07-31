using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.SubscriptionCategoryRepo;

public class SubscriptionCategoryReadRepository : ReadRepository<SubscriptionCategory>, ISubscriptionCategoryReadRepository
{
    public SubscriptionCategoryReadRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

