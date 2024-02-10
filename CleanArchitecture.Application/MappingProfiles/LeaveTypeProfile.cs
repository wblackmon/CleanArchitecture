using AutoMapper;
using CleanArchitecture.Application.Features.Commands.CreateLeaveType;
using CleanArchitecture.Application.Features.Queries.LeaveTypes.GetLeaveTypes;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    LeaveTypeProfile()
    {
        // Mapping from LeaveType to LeaveTypeDto
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();

        // Mapping from LeaveType to LeaveTypeDetailsDto with no reverse mapping
        // This is because LeaveTypeDetailsDto is a read-only DTO
        CreateMap<LeaveType, LeaveTypeDetailsDto>();

        // Mapping from CreateLeaveTypeCommand to LeaveType
        CreateMap<CreateLeaveTypeCommand, LeaveType>();

    }
}
