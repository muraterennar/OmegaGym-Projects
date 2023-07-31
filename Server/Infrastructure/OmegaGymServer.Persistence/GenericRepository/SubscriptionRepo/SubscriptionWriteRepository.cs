using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.SubscriptionRepo;

public class SubscriptionWriteRepository : WriteRepository<Subscription>, ISubscriptionWriteRepository
{
    public SubscriptionWriteRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

