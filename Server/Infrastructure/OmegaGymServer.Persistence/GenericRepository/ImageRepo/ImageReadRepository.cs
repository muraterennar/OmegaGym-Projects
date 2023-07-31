using OmegaGymServer.Application.GenericRepository.ImageRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.ImageRepo;

public class ImageReadRepository : ReadRepository<Image>, IImageReadRepository
{
    public ImageReadRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

