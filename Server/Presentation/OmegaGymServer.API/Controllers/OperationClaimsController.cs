using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.Consts;
using OmegaGymServer.Application.CustomAttributes;
using OmegaGymServer.Application.Features.Commands.OperationCliamCommand.DeleteOperationClaimCommand;
using OmegaGymServer.Application.Features.Commands.OperationCliamCommand.InsertOperationClaimCommand;
using OmegaGymServer.Application.Features.Commands.OperationCliamCommand.UpdateOperationCliamCommand;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetAllOperationClaim;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByIdOperationClaim;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByNameOperationClaim;

namespace OmegaGymServer.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        readonly IMediator _mediator;

        public OperationClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: getall
        [HttpGet]
        [AuthorizeDefination(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOperationClaimQueryRequest getAllOperationClaimQueryRequest)
        {
            var response = await _mediator.Send(getAllOperationClaimQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: getbyid
        [HttpGet("getbyid")]
        [AuthorizeDefinationAttribute(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> GetById([FromQuery] GetByIdOperationClaimQueryRequest getByIdOperationClaimQueryRequest)
        {
            var response = await _mediator.Send(getByIdOperationClaimQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //GET: getbyname
        [HttpGet("getbyname")]
        [AuthorizeDefinationAttribute(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> GetByName([FromQuery] GetByNameOprationCliamQueryRequest getByNameOprationCliamQueryRequest)
        {
            var response = await _mediator.Send(getByNameOprationCliamQueryRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Add Operation
        [HttpPost("add")]
        [AuthorizeDefinationAttribute(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Add([FromQuery] InsertOperationCliamCommandRequest insertOperationCliamCommandRequest)
        {
            var response = await _mediator.Send(insertOperationCliamCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //POST: Update operasyonu
        [HttpPost("update")]
        [AuthorizeDefinationAttribute(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Update([FromQuery] UpdateOperationClaimCommandRequest updateOperationClaimCommandRequest)
        {
            var response = await _mediator.Send(updateOperationClaimCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }

        //DELETE: Delete Operasyonu
        [HttpDelete("delete")]
        [AuthorizeDefinationAttribute(Roles = new string[] { AuthorizeDefinationConstants.Admin })]
        public async Task<IActionResult> Delete([FromQuery] DeleteOperationClaimCommandRequest deleteOperationClaimCommandRequest)
        {
            var response = await _mediator.Send(deleteOperationClaimCommandRequest);
            return response != null ? Ok(response) : BadRequest(response);
        }
    }
}

