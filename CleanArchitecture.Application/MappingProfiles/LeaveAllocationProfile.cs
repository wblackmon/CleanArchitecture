using AutoMapper;
using CleanArchitecture.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using CleanArchitecture.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationCommand>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationCommand>().ReverseMap();

        }

    }
}
