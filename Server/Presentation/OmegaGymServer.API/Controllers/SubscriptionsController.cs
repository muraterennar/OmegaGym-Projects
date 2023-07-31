using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Consts;
using OmegaGymServer.Application.CustomAttributes;
using OmegaGymServer.Application.Features.Commands.SubscriptionCommand.DeleteSubscriptionCommand;
using OmegaGymServer.Application.Features.Commands.SubscriptionCommand.InsertSubscriptionCommand;
using OmegaGymServer.Application.Features.Commands.SubscriptionCommand.UpdateSubscriptionCommand;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetAllSubscription;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByCategoryIdSubscription;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByIdSubscription;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByNameSubscription;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetDetailsSubcription;

namespace OmegaGymServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET: Get All operation
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSubscriptionQueryRequest getAllSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getAllSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get by Id operation
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdSubscriptionQueryRequest getByIdSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getByIdSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }


        //GET: Get by Category  Id operation
        [HttpGet("getbycategoryid")]
        public async Task<IActionResult> GetByCategoryId([FromQuery] GetByCategoryIdSubscriptionQueryRequest getByCategoryIdSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getByCategoryIdSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By Title operation
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName([FromQuery] GetByNameSubscriptionQueryRequest getByNameSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getByNameSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By Detail Operation
        [HttpGet("details")]
        public async Task<IActionResult> GetByDetails([FromQuery] GetDetailsSubscriptionQueryRequest getDetailsSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getDetailsSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Add operation
        [HttpPost("add")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Insert([FromQuery] InsertSubscriptionCommandRequest insertSubscriptionCommandRequest)
        {
            var response = await _mediator.Send(insertSubscriptionCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Update operation
        [HttpPost("update")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Update([FromQuery] UpdateSubscriptionCommandRequest updateSubscriptionCommandRequest)
        {
            var response = await _mediator.Send(updateSubscriptionCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //DELETE: Delete operation
        [HttpDelete("delete")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Delete([FromQuery] DeleteSubscriptionCommandRequest deleteSubscriptionCommandRequest)
        {
            var response = await _mediator.Send(deleteSubscriptionCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }
    }
}

