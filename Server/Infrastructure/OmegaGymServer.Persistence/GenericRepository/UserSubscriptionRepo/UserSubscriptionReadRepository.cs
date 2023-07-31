using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.UserSubscriptionRepo
{
    public class UserSubscriptionReadRepository : ReadRepository<UserSubscription>, IReadUserSubscriptionRepository
    {
        public UserSubscriptionReadRepository(OmegaGymEfDbContext context) : base(context)
        {
        }
    }
}

