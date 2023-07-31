using OmegaGymServer.Application.DTOs.OperationClaimDTOs;

namespace OmegaGymServer.Application.Abstract.Services;

public interface IOperationClaimService
{
    Task<GetByNameOperationClaimDTO> GetByNameOprationClaimAsync(string name);
}

