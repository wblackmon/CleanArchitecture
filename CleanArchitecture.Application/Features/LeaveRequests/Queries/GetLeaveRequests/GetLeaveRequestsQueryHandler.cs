using AutoMapper;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetail;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequests;

public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, List<LeaveRequestsDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    //private readonly IUserService _userService;
    public GetLeaveRequestsQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)//, IUserService userService)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        //_userService = userService;
    }
    public async Task<List<LeaveRequestsDto>> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = new List<LeaveRequest>();
        var leaveRequestDtos = new List<LeaveRequestsDto>();

        if (request.IsLoggedInUser)
        {
            //leaveRequests = await _leaveRequestRepository.GetLeaveRequestsByEmployeeId(_userService.UserId);
            leaveRequestDtos = _mapper.Map<List<LeaveRequestsDto>>(leaveRequests);
        }
        else
        {
            leaveRequests = await _leaveRequestRepository.GetAllLeaveRequests();
            leaveRequestDtos = _mapper.Map<List<LeaveRequestsDto>>(leaveRequests);

            foreach (var leaveRequestDto in leaveRequestDtos)
            {
                //leaveRequestDto.Employee = await _userService.GetEmployeeById(leaveRequestDto.RequestingEmployeeId);
            }
        }

        return leaveRequestDtos;
    }
}
