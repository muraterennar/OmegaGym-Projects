using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByIdUserQuery;

public class GetByIdUserQueryRequest : IRequest<GetByIdUserQueryResponse>
{
    public Guid Id { get; set; }
}

