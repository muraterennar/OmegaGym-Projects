using OmegaGymServer.Application.GenericRepository.ImageRepo;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository.ImageRepo;

public class ImageWriteRepository : WriteRepository<Image>, IImageWriteRepository
{
    public ImageWriteRepository(OmegaGymEfDbContext context) : base(context)
    {
    }
}

