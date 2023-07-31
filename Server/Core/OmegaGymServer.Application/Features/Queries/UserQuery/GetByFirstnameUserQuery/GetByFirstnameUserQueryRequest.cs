using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetByFirstnameUserQuery;

public class GetByFirstnameUserQueryRequest : IRequest<GetByFirstnameUserQueryResponse>
{
    public string FirstName { get; set; }
}

