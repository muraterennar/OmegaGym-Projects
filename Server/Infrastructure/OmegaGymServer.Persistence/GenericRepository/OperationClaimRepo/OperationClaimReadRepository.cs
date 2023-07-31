using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.OperationClaimRepo;

public class OperationClaimReadRepository : ReadRepository<OperationClaim>, IOperationClaimReadRepository
{
    public OperationClaimReadRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

