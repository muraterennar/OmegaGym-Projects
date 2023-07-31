using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }

    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public Guid? UserSubscriptionId { get; set; }
    public virtual UserSubscription UserSubscription { get; set; }

    public Guid OperationClaimId { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public string SecurityStamp { get; set; }
    public string SingleCode { get; set; }
}

