using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Consts;
using OmegaGymServer.Application.CustomAttributes;
using OmegaGymServer.Application.Features.Commands.UserCommand.DeleteUserCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.InsertUserCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.UpdatePasswordCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.UpdateUserCommand;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetAllUserQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByFirstnameUserQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByIdUserQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByOperationClaimIdQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByUsernameUserQuery;

namespace OmegaGymServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET: Get All Operation
        [HttpGet]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserQueryRequest getAllUserQueryRequest)
        {
            var response = await _mediator.Send(getAllUserQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get by Id operation
        [HttpGet("getbyid")]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetById([FromQuery] GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            var response = await _mediator.Send(getByIdUserQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By Operation Cliam Id Operation
        [HttpGet("getbyoperationclaimid")]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetByOperationClaimId([FromQuery] GetByOperationClaimIdUserQueryRequest getByOperationClaimIdUserQueryRequest)
        {
            var response = await _mediator.Send(getByOperationClaimIdUserQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By FirstName Operation
        [HttpGet("getbyfirstname")]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetByFirstname([FromQuery] GetByFirstnameUserQueryRequest getByFirstnameUserQueryRequest)
        {
            var response = await _mediator.Send(getByFirstnameUserQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: Get By Username Operation
        [HttpGet("getbyusername")]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> GetByUsername([FromQuery] GetByUsernameUserQueryRequest getByUsernameUserQueryRequest)
        {
            var response = await _mediator.Send(getByUsernameUserQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST : Add operation
        [HttpPost("add")]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Add([FromBody] InsertUserCommandRequest insertUserCommandRequest)
        {
            var response = await _mediator.Send(insertUserCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Update operation
        [HttpPost("update")]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin, AuthorizeDefinationConstants.User })]
        public async Task<IActionResult> Update([FromQuery] UpdateUserCommandRequest updateUserCommandRequest)
        {
            var response = await _mediator.Send(updateUserCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //DELETE: Delete Operasyonu
        [HttpDelete("delete")]
        [Authorize]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserCommandRequest deleteUserCommandRequest)
        {
            var response = await _mediator.Send(deleteUserCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Update Password
        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            var response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }
    }
}

