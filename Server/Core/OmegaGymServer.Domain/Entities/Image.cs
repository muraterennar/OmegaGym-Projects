using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}

