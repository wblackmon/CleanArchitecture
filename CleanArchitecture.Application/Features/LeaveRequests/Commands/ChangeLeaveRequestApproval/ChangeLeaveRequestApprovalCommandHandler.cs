using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Models.Email;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;
    public ChangeLeaveRequestApprovalCommandHandler(
        ILeaveRequestRepository leaveRequestRepository, 
        ILeaveAllocationRepository leaveAllocationRepository, 
        ILeaveTypeRepository leaveTypeRepository, 
        IEmailSender emailSender, 
        IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _emailSender = emailSender;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id) ;

        if (leaveRequest == null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        leaveRequest.Approved = request.Approved;

        // if the leave request is approved, get and update the leave allocation
        if (request.Approved)
        {
            int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
            var allocation = await _leaveAllocationRepository.GetLeaveAllocationByEmployeeIdAndLeaveTypeId(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
            allocation.NumberOfDays -= daysRequested;
            await _leaveAllocationRepository.UpdateAsync(allocation);
        }
        // send email to employee
        try
        {
            var email = new EmailMessage()
            {
                To = "employee@localhost", 
                Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been {(request.Approved ? "approved" : "rejected")}.", 
                Subject = "Leave Request Status" 
            };
        }
        catch (Exception)
        {
            // TODO: log error
        }
        return Unit.Value;
    }

}
