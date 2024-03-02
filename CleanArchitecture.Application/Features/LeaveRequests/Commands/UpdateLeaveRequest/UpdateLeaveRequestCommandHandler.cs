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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;
    private readonly IEmailSender _emailSender;
    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, 
        ILeaveTypeRepository leaveTypeRepository, 
        IMapper mapper, 
        IAppLogger<UpdateLeaveRequestCommandHandler> logger, 
        IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _logger = logger;
        _emailSender = emailSender;
    }
    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest == null)
        {
            _logger.LogError($"LeaveRequest with id {request.Id} was not found.");
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        _mapper.Map(request, leaveRequest);

        await _leaveRequestRepository.UpdateAsync(leaveRequest);
        _logger.LogInformation($"LeaveRequest with id {request.Id} was updated.");

        try
        {
            var emailMessage = new EmailMessage
            {
                To = "manager@localhost", // Get email from employee record
                Subject = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} has been updated.",
                Body = $"Your leave request has been updated to {leaveRequest.Approved}." // Add more details
            };
            await _emailSender.SendEmail(emailMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to send email for leave request update for {leaveRequest.Id}.", ex.Message);
            // TODO: handle email exception
            throw;
        }
        return Unit.Value; 
    }
}
