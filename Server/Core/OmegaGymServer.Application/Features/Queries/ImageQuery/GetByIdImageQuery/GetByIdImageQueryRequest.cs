using MediatR;

namespace OmegaGymServer.Application.Features.Queries.ImageQuery.GetByIdImageQuery;

public class GetByIdImageQueryRequest : IRequest<GetByIdImageQueryResponse>
{
    public Guid Id { get; set; }
}

