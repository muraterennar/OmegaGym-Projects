using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.SubscriptionRepo;

public class SubscriptionReadRepository : ReadRepository<Subscription>, ISubscriptionReadRepository
{
    public SubscriptionReadRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

