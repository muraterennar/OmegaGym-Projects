using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Domain.Entities;

public class Franchising : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

