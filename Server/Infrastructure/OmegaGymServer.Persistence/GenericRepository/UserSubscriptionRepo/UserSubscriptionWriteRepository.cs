using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.UserSubscriptionRepo;

public class UserSubscriptionWriteRepository : WriteRepository<UserSubscription>, IWriteUserSubscriptionRepository
{
    public UserSubscriptionWriteRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

