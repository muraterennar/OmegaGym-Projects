using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserQuery.GetAllUserQuery
{
    public class GetAllUserQueryRequest : IRequest<List<GetAllUserQueryResponse>>
    {

    }
}

