using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.ImageDTOs;

namespace OmegaGymServer.Application.Features.Commands.ImageCommand.UpdateImageCommand;

public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommandRequest, UpdateImageCommandResponse>
{
    readonly IImageService _imageService;

    public UpdateImageCommandHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<UpdateImageCommandResponse> Handle(UpdateImageCommandRequest request, CancellationToken cancellationToken)
    {
        var model = new GetImageDTO
        {
            Id = request.Id,
            ImageName = request.ImageName,
            ImageUrl = request.ImageUrl
        };

        bool updatedModel = await _imageService.UpdateImageAsync(model);

        return new()
        {
            isSuccess = updatedModel
        };
    }
}

