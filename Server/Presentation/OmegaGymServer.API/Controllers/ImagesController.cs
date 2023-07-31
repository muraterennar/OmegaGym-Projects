using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Features.Commands.ImageCommand.DeleteImageCommand;
using OmegaGymServer.Application.Features.Commands.ImageCommand.InsertImageCommand;
using OmegaGymServer.Application.Features.Commands.ImageCommand.UpdateImageCommand;
using OmegaGymServer.Application.Features.Queries.ImageQuery.GetAllImageQuery;
using OmegaGymServer.Application.Features.Queries.ImageQuery.GetByIdImageQuery;
using OmegaGymServer.Application.Features.Queries.ImageQuery.GetByNameImageQuery;

namespace OmegaGymServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    readonly IMediator _mediator;

    public ImagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllImageQueryRequest getAllImageQueryRequest)
    {
        var response = await _mediator.Send(getAllImageQueryRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdImageQueryRequest getByIdImageQueryRequest)
    {
        var response = await _mediator.Send(getByIdImageQueryRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    [HttpGet("getbyname")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameImageQueryRequest getByNameImageQueryRequest)
    {
        var response = await _mediator.Send(getByNameImageQueryRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add(InsertImageCommandRequest insertImageCommandRequest)
    {
        var response = await _mediator.Send(insertImageCommandRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateImageCommandRequest updateImageCommandRequest)
    {
        var response = await _mediator.Send(updateImageCommandRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteImageCommandRequest deleteImageCommandRequest)
    {
        var response = await _mediator.Send(deleteImageCommandRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }
}

