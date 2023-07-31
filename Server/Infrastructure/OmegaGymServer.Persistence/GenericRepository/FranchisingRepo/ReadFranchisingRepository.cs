using OmegaGymServer.Application.GenericRepository.FranchisingRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.FranchisingRepo;

public class ReadFranchisingRepository : ReadRepository<Franchising>, IFranchisingReadRepository
{
    public ReadFranchisingRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

