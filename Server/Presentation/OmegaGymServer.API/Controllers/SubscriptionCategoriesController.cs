using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Consts;
using OmegaGymServer.Application.CustomAttributes;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.DeleteSubscriptionCategoryCommand;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.InsertSubscriptionCategoryCommand;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.UpdateSubscriptionCategoryCommand;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetAllSubscriptionCategory;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByIdForSubscriptionCategory;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByNameSubscriptionCategory;

namespace OmegaGymServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionCategoriesController : ControllerBase
{
    readonly IMediator _mediator;

    public SubscriptionCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: getall operation
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllSubscriptionCategoryQueryRequest getAllSubscriptionCategoryQueryRequest)
    {
        //var model = _subscriptionCategoryReadRepository.GetAll();

        var response = await _mediator.Send(getAllSubscriptionCategoryQueryRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    // GET: get by id operation
    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdSubscriptionCategoryQueryRequest getByIdSubscriptionCategoryQueryRequest)
    {
        var response = await _mediator.Send(getByIdSubscriptionCategoryQueryRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    //GET: get by name operation
    [HttpGet("getbyname")]
    public async Task<IActionResult> GetByName([FromQuery] GetByNameSubscriptionCategoryQueryRequest getByNameSubscriptionCategoryQueryRequest)
    {
        var response = await _mediator.Send(getByNameSubscriptionCategoryQueryRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    // POST: Add operation
    [HttpPost("add")]
    [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
    public async Task<IActionResult> Add([FromQuery] InsertSubscriptionCategoryQueryRequest insertSubscriptionCategoryQueryRequest)
    {
        var response = await _mediator.Send(insertSubscriptionCategoryQueryRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    // POST: Update Operation
    [HttpPost("update")]
    [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
    public async Task<IActionResult> Update([FromQuery] UpdateSubscriptionCategoryCommandRequest updateSubscriptionCategoryCommandRequest)
    {
        var response = await _mediator.Send(updateSubscriptionCategoryCommandRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }

    // DELETE: Delete operation
    [HttpDelete("delete")]
    [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
    public async Task<IActionResult> Delete([FromQuery] DeleteSubscriptionCategoryCommandRequest deleteSubscriptionCategoryCommandRequest)
    {
        var response = await _mediator.Send(deleteSubscriptionCategoryCommandRequest);
        return response != null ? Ok(response) : BadRequest(response);
    }
}

