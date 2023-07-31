using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Queries.ImageQuery.GetByNameImageQuery;

public class GetByNameImageQueryHandler : IRequestHandler<GetByNameImageQueryRequest, GetByNameImageQueryRespone>
{
    readonly IImageService _imageService;

    public GetByNameImageQueryHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<GetByNameImageQueryRespone> Handle(GetByNameImageQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _imageService.GetByNameImageAsync(request.ImageName);
        return model as GetByNameImageQueryRespone;
    }
}

