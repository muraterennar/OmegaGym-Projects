using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.UserRepo;

public class UserReadRepository : ReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

