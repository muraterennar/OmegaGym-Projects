using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.ImageDTOs;

namespace OmegaGymServer.Application.Features.Queries.ImageQuery.GetByIdImageQuery;

public class GetByIdImageQueryHandler : IRequestHandler<GetByIdImageQueryRequest, GetByIdImageQueryResponse>
{
    readonly IImageService _imageService;

    public GetByIdImageQueryHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<GetByIdImageQueryResponse> Handle(GetByIdImageQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _imageService.GetByIdImageAsync(request.Id);
        return model as GetByIdImageQueryResponse;
    }
}

