using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Consts;
using OmegaGymServer.Application.CustomAttributes;
using OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.DeleteUserSubscriptionCommand;
using OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.InsertUserSubscriptionCommand;
using OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.UpdateUserSubscriptionCommand;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetAllUserSubscription;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByIdUserSubscription;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetBySubscriptionIdUserSubscription;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByUserIdUserSubscription;

namespace OmegaGymServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserSubscriptionsController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserSubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET: Get All Operation
        [HttpGet]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserSubscriptionQueryRequest getAllUserSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getAllUserSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By Id Operation
        [HttpGet("getbyid")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetById([FromQuery] GetByIdUserSubscriptionQueryRequest getByIdUserSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getByIdUserSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By User ID operation
        [HttpGet("getbyuserid")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetByUserId([FromQuery] GetByUserIdUserSubscriptionQueryRequest getByUserIdUserSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getByUserIdUserSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By Subscription Id Operation
        [HttpGet("getbysubscriptionid")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetBySubscriptionId([FromQuery] GetBySubscriptionIdUserSubscriptionQueryRequest getBySubscriptionIdUserSubscriptionQueryRequest)
        {
            var response = await _mediator.Send(getBySubscriptionIdUserSubscriptionQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Added Operation
        [HttpPost("add")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> Add([FromQuery] InsertUserSubscriptionCommandRequest insertUserSubscriptionCommandRequest)
        {
            var response = await _mediator.Send(insertUserSubscriptionCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Update Operasyonu
        [HttpPost("update")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> Update([FromQuery] UpdateUserSubscriptionCommandRequest updateUserSubscriptionCommandRequest)
        {
            var response = await _mediator.Send(updateUserSubscriptionCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //DELETE: Delete Operasyonu
        [HttpDelete("delete")]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserSubscriptionCommandRequest deleteUserSubscriptionCommandRequest)
        {
            var response = await _mediator.Send(deleteUserSubscriptionCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }
    }
}

