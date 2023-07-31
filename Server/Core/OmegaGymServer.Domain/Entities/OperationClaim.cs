using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Domain.Entities;

public class OperationClaim : BaseEntity
{
    public string RoleName { get; set; }

    public virtual ICollection<User> Users { get; set; }
}

