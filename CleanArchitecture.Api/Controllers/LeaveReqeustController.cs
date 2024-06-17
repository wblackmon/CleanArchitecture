using CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequests;
using CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.CancelLeaveRequestCommand;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.ChangeLeaveRequestApproval;
using CleanArchitecture.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveReqeustController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveReqeustController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveReqeustsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestsDto>>> Get(bool isLoggedInUser = false)
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestsQuery());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveReqeustsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDetailDto>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailQuery { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveReqeustsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequest)
        {
            var response = await _mediator.Send(leaveRequest);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
        
        // PUT api/<LeaveReqeustsController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequest)
        {
            await _mediator.Send(leaveRequest);
            return NoContent();
        }

        // PUT api/<LeaveReqeustsController>/CancelRequest
        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand leaveRequest)
        {
            await _mediator.Send(leaveRequest);
            return NoContent();
        }

        // PUT api/<LeaveReqeustsController>/UpdateApproval
        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateApproval(ChangeLeaveRequestApprovalCommand leaveRequest)
        {
            await _mediator.Send(leaveRequest);
            return NoContent();
        }

        // DELETE api/<LeaveReqeustsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
