using OmegaGymServer.Application.DTOs.ImageDTOs;

namespace OmegaGymServer.Application.Features.Queries.ImageQuery.GetAllImageQuery;

public class GetAllImageQueryResponse
{
    public Guid Id { get; set; }
    public string ImageName { get; set; }
    public string ImageUrl { get; set; }
}

