﻿using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
            return leaveTypes;
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDto> Get(int id)
        {
            await Task.Delay(1);
            return new LeaveTypeDto();
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
