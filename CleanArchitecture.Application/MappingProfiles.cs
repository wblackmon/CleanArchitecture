using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    public class MappingProfiles : Profile
    {
        MappingProfiles()
        {
            //CreateMap<Domain.LeaveType, Models.LeaveTypeDto>().ReverseMap();
            //CreateMap<Domain.LeaveType, Models.CreateLeaveTypeDto>().ReverseMap();
            //CreateMap<Domain.LeaveType, Models.UpdateLeaveTypeDto>().ReverseMap();

            //CreateMap<Domain.LeaveAllocation, Models.LeaveAllocationDto>().ReverseMap();
            //CreateMap<Domain.LeaveAllocation, Models.CreateLeaveAllocationDto>().ReverseMap();
            //CreateMap<Domain.LeaveAllocation, Models.UpdateLeaveAllocationDto>().ReverseMap();

            //CreateMap<Domain.LeaveRequest, Models.LeaveRequestDto>().ReverseMap();
            //CreateMap<Domain.LeaveRequest, Models.CreateLeaveRequestDto>().ReverseMap();
            //CreateMap<Domain.LeaveRequest, Models.UpdateLeaveRequestDto>().ReverseMap();
        }
    }
}
