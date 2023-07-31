using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByUsernameUserQuery;

public class GetByUsernameUserQueryResponse
{
    public Guid Id { get; set; }
    public Guid OperationClaimId { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

