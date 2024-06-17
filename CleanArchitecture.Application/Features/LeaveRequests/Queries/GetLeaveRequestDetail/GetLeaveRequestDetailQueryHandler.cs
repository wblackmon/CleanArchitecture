using AutoMapper;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetail;

public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    //private readonly IUserService _userService;
    public GetLeaveRequestDetailQueryHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)//, IUserService userService)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        //_userService = userService;
    }
    public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = _leaveRequestRepository.GetLeaveRequestByid(request.Id);
        var leaveRequestDto = _mapper.Map<LeaveRequestDetailDto>(leaveRequest);

        if (leaveRequestDto == null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        //leaveRequestDto.Employee = await _userService.GetEmployeeById(leaveRequestDto.RequestingEmployeeId);
        return leaveRequestDto;
    }
}
