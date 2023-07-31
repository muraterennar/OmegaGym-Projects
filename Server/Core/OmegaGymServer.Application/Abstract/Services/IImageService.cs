using OmegaGymServer.Application.DTOs.ImageDTOs;

namespace OmegaGymServer.Application.Abstract.Services;

public interface IImageService
{
    List<GetImageDTO> GetAllImage();
    Task<GetImageDTO> GetByIdImageAsync(Guid id);
    Task<GetImageDTO> GetByNameImageAsync(string imageName);

    Task<bool> AddImageAsync(GetImageDTO imageDTO);
    Task<bool> UpdateImageAsync(GetImageDTO imageDTO);
    Task<bool> DeleteImageAsync(Guid id);
}

