using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.ImageDTOs;

namespace OmegaGymServer.Application.Features.Commands.ImageCommand.InsertImageCommand;

public class InsertImageCommandHandler : IRequestHandler<InsertImageCommandRequest, InsertImageCommandResponse>
{
    readonly IImageService _imageService;

    public InsertImageCommandHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<InsertImageCommandResponse> Handle(InsertImageCommandRequest request, CancellationToken cancellationToken)
    {
        var model = new GetImageDTO
        {
            ImageName = request.ImageName,
            ImageUrl = request.ImageUrl
        };

        bool isSuccess = await _imageService.AddImageAsync(model);

        return new()
        {
            IsSuccess = isSuccess
        };
    }
}

