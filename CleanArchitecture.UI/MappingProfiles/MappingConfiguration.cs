using AutoMapper;
using CleanArchitecture.UI.Models.LeaveTypes;
using CleanArchitecture.UI.Services.Base;

namespace CleanArchitecture.UI.MappingProfiles
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVm>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVm>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypeVm>().ReverseMap();
        }
    }
}
