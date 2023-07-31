using MediatR;

namespace OmegaGymServer.Application.Features.Queries.ImageQuery.GetByNameImageQuery;

public class GetByNameImageQueryRequest : IRequest<GetByNameImageQueryRespone>
{
    public string ImageName { get; set; }
}

