using OmegaGymServer.Application.GenericRepository.FranchisingRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.FranchisingRepo;

public class WriteFranchisingRepository : WriteRepository<Franchising>, IFranchinsingWriteRepository
{
    public WriteFranchisingRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

