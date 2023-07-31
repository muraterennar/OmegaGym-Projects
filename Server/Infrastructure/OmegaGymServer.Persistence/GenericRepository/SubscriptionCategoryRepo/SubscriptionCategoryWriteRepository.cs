using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.SubscriptionCategoryRepo;

public class SubscriptionCategoryWriteRepository : WriteRepository<SubscriptionCategory>, ISubscriptionCategoryWriteRepository
{
    public SubscriptionCategoryWriteRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

