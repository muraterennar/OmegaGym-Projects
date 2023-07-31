using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetAllOperationClaim;

public class GetAllOperationClaimQueryResponse
{
    public Guid Id { get; set; }
    public string RoleName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

