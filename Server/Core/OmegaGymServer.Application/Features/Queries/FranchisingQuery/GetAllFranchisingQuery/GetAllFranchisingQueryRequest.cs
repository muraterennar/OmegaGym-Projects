using MediatR;

namespace OmegaGymServer.Application.Features.Queries.FranchisingQuery.GetAllFranchisingQuery;

public class GetAllFranchisingQueryRequest : IRequest<List<GetAllFranchisingQueryResponse>>
{
}