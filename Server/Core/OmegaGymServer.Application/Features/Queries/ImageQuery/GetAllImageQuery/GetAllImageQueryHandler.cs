using MediatR;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.ImageDTOs;

namespace OmegaGymServer.Application.Features.Queries.ImageQuery.GetAllImageQuery
{
    public class GetAllImageQueryHandler : IRequestHandler<GetAllImageQueryRequest, List<GetAllImageQueryResponse>>
    {
        readonly IImageService _imageService;

        public GetAllImageQueryHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<List<GetAllImageQueryResponse>> Handle(GetAllImageQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _imageService.GetAllImage();

            return response.Select(x => new GetAllImageQueryResponse
            {
                Id = x.Id,
                ImageName = x.ImageName,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}

