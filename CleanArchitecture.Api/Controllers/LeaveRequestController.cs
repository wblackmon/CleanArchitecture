using CleanArchitecture.Application.Features.LeaveRequests.Commands.CancelLeaveRequestCommand;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetails;
using CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestLController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestsDetailsDto>>> Get(bool isLoggedInUser = false)
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestsQuery());
            return Ok(leaveRequests);
        }

        // GET: api/<LeaveRequestLController>/5
        [HttpGet]
        public async Task<ActionResult<LeaveRequestsDetailsDto>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsQuery() { Id = id });
            return Ok(leaveRequest);
        }

        // POST: api/<LeaveRequestLController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Post([FromBody] CreateLeaveRequestCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(Post), new { id = response });
        }

        // PUT: api/<LeaveRequestLController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveRequestCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT: api/<LeaveRequestLController>/CancelReqeust
        [HttpPut("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest([FromBody] CancelLeaveRequestCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT: api/<LeaveRequestLController>/UpdateApproval
        [HttpPut("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateApproval([FromBody] UpdateLeaveRequestCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        // DELETE: api/<LeaveRequestLController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
