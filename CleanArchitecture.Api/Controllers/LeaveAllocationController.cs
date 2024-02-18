using CleanArchitecture.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using CleanArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get LeaveAllocationDtos
        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            object leaveAllocations = await _mediator.Send(new GetLeaveAllocationsQuery());
            return Ok(leaveAllocations);
        }

        // Get LeaveAllocationDetailsDto by id
        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDetailsDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQuery() { Id = id });
            return Ok(leaveAllocation);
        }

        // Create a new LeaveAllocation
        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = response }, response);
        }

        // Update LeaveAllocation
        // PUT api/<LeaveAllocationController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
