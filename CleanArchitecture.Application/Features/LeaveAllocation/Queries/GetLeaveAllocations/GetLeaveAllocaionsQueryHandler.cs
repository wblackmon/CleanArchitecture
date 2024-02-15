using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocaionsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocaionsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
        {
            // TODO
            // Get records for specific employee
            // Get allocations per employee
            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllLeaveAllocaions();
            var mappedLeaveAllocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
            return mappedLeaveAllocations;
        }
    }
}
