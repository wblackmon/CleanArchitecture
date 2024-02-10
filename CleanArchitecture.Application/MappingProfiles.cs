using AutoMapper;
using CleanArchitecture.Application.Features.Queries.LeaveTypes.GetLeaveTypes;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application;

public class MappingProfiles : Profile
{
    MappingProfiles()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, GetLeaveTypeDetailsDto>().ReverseMap();

    }
}
