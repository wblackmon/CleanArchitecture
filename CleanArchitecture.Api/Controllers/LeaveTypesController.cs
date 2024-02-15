using CleanArchitecture.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Commands.DeleteLeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        // Get all leave types
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
            return leaveTypes;
        }

        // GET api/<LeaveTypesController>/5
        // Get a leave type by id
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery() { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        // Create a new leave type
        [HttpPost]
        public async Task<int> Post(CreateLeaveTypeCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        // PUT api/<LeaveTypesController>/5
        // Update a leave type
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(UpdateLeaveTypeCommand command)

        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        // Delete a leave type
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();

        }
    }
}
