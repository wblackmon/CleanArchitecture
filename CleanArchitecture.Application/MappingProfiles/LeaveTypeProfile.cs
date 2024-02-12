using AutoMapper;
using CleanArchitecture.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }
}
