using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Features.Commands.FranchisingCommand.AddFranchisingCommand;
using OmegaGymServer.Application.Features.Commands.FranchisingCommand.DeleteFranchisingCommand;
using OmegaGymServer.Application.Features.Queries.FranchisingQuery.GetAllFranchisingQuery;

namespace OmegaGymServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FranchisingsController : ControllerBase
{
    readonly IMediator _mediator;

    public FranchisingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromBody] GetAllFranchisingQueryRequest getAllFranchisingQueryRequest)
    {
        var response = await _mediator.Send(getAllFranchisingQueryRequest);
        return Ok(response);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddFranchisingCommandRequest addFranchisingCommandRequest)
    {
        var response = await _mediator.Send(addFranchisingCommandRequest);
        return Ok(response);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Remove([FromBody] DeleteFranchisingCommandRequest deleteFranchisingCommandRequest)
    {
        var response = await _mediator.Send(deleteFranchisingCommandRequest);
        return Ok(response);
    }
}

