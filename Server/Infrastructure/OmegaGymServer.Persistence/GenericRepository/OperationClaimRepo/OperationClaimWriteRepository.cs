using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.OperationClaimRepo;

public class OperationClaimWriteRepository : WriteRepository<OperationClaim>, IOperationClaimWriteRepositoory
{
    public OperationClaimWriteRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

