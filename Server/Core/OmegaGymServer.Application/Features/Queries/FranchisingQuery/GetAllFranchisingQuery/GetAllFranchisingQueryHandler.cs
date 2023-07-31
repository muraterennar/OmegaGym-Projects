using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Queries.FranchisingQuery.GetAllFranchisingQuery;

public class GetAllFranchisingQueryHandler : IRequestHandler<GetAllFranchisingQueryRequest, List<GetAllFranchisingQueryResponse>>
{
    readonly IFranchisingService _franchisingService;

    public GetAllFranchisingQueryHandler(IFranchisingService franchisingService)
    {
        _franchisingService = franchisingService;
    }

    public async Task<List<GetAllFranchisingQueryResponse>> Handle(GetAllFranchisingQueryRequest request, CancellationToken cancellationToken)
    {
        var model = _franchisingService.GetAll();
        return model.Select(s => new GetAllFranchisingQueryResponse
        {
            Id = s.Id.ToString(),
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            Phone = s.Email
        }).ToList();
    }
}

