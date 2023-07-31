using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.ImageDTOs;
using OmegaGymServer.Application.GenericRepository.ImageRepo;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Persistence.Services;

public class ImageService : IImageService
{
    readonly IImageReadRepository _imageReadRepository;
    readonly IImageWriteRepository _imageWriteRepository;

    public ImageService(IImageReadRepository imageReadRepository, IImageWriteRepository imageWriteRepository)
    {
        _imageReadRepository = imageReadRepository;
        _imageWriteRepository = imageWriteRepository;
    }

    public List<GetImageDTO> GetAllImage()
    {
        var models = _imageReadRepository.GetAll();
        return models.Select(x => new GetImageDTO
        {
            Id = x.Id,
            ImageName = x.ImageName,
            ImageUrl = x.ImageUrl
        }).ToList();
    }

    public async Task<GetImageDTO> GetByIdImageAsync(Guid id)
    {
        var model = await _imageReadRepository.GetByIdAsync(id);
        return new()
        {
            Id = model.Id,
            ImageName = model.ImageName,
            ImageUrl = model.ImageUrl
        };
    }

    public async Task<GetImageDTO> GetByNameImageAsync(string imageName)
    {
        var model = await _imageReadRepository.GetSingleAsync(x => x.ImageName == imageName);
        return new()
        {
            Id = model.Id,
            ImageName = model.ImageName,
            ImageUrl = model.ImageUrl
        };
    }

    public async Task<bool> AddImageAsync(GetImageDTO imageDTO)
    {
        var model = await _imageWriteRepository.AddAsync(new Image
        {
            ImageName = imageDTO.ImageName,
            ImageUrl = imageDTO.ImageUrl
        });

        await _imageWriteRepository.SaveAsync();

        return model;
    }

    public async Task<bool> UpdateImageAsync(GetImageDTO imageDTO)
    {
        var getModel = await _imageReadRepository.GetByIdAsync(imageDTO.Id);

        getModel.ImageName = imageDTO.ImageName == null ? getModel.ImageName : $"{DateTime.Now}_{imageDTO.ImageName}";
        getModel.ImageUrl = imageDTO.ImageUrl == null ? getModel.ImageUrl : imageDTO.ImageUrl;

        var updatedModel = _imageWriteRepository.Update(getModel);

        await _imageWriteRepository.SaveAsync();

        return updatedModel;
    }

    public async Task<bool> DeleteImageAsync(Guid id)
    {
        var removedModel = await _imageWriteRepository.RemoveAsync(id);
        await _imageWriteRepository.SaveAsync();

        return removedModel;
    }
}

