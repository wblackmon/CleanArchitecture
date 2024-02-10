using AutoMapper;

namespace CleanArchitecture.Application
{
    public class MappingProfiles : Profile
    {
        MappingProfiles()
        {
            CreateMap<Domain.LeaveType, LeaveTypeDto>().ReverseMap();
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
