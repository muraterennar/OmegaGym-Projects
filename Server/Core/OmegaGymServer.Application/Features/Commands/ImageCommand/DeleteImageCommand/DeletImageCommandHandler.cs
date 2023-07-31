using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.ImageCommand.DeleteImageCommand;

public class DeletImageCommandHandler : IRequestHandler<DeleteImageCommandRequest, DeleteImageCommandResponse>
{
    readonly IImageService _imageService;

    public DeletImageCommandHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<DeleteImageCommandResponse> Handle(DeleteImageCommandRequest request, CancellationToken cancellationToken)
    {
        var deletedModel = await _imageService.DeleteImageAsync(request.Id);

        return new()
        {
            IsSuccess = deletedModel
        };
    }
}

