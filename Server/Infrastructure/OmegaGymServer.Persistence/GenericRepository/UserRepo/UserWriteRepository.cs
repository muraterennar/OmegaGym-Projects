using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.UserRepo;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

