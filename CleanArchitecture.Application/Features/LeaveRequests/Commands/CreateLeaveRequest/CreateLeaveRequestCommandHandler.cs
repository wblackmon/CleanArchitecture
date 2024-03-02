using AutoMapper;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Models.Email;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    //private readonly IUserService _userService;
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;
    public CreateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository, 
        ILeaveTypeRepository leaveTypeRepository, 
        ILeaveAllocationRepository leaveAllocationRepository, 
        //IUserService userService, 
        IEmailSender emailSender, 
        IMapper mapper,
        IAppLogger<CreateLeaveRequestCommandHandler> logger)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _leaveAllocationRepository = leaveAllocationRepository;
        //_userService = userService;
        _emailSender = emailSender;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogError($"Validation errors - {string.Join(", ", validationResult.Errors)}");
            throw new BadRequestException("Invalid Leave Request", validationResult);
        }


        // Get requesting employee id
        //var employeeId = _userService.UserId;

        // Get leave allocation
        //var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationByEmployeeIdAndLeaveTypeId(employeeId, request.LeaveTypeId);

        //if (leaveAllocation is null)
        //{
        //    validationResult.Errors.Add(new ValidationFailure(nameof(request.LeaveTypeId), "You do not have any allocations for this leave type."));
        //    _logger.LogError($"User did not have any leave allocations for leave type id {leaveAllocation.LeaveTypeId} - {string.Join(", ", validationResult.Errors)}");
        //    throw new BadRequestException("Invalid Leave Request", validationResult);
        //}

        int daysRequested = (int)(request.EndDate - request.StartDate).TotalDays;
        //if (daysRequested > leaveAllocation.NumberOfDays)
        //{
        //    validationResult.Errors.Add(new ValidationFailure(nameof(request), "You do not have enough days for this request."));
        //    _logger.LogError($"User did not have enough days for this request {leaveAllocation.NumberOfDays}- {string.Join(", ", validationResult.Errors)}");
        //    throw new BadRequestException("Invalid Leave Request", validationResult);
        //}

        // Create leave request
        var leaveRequest = _mapper.Map<Domain.Entities.LeaveRequest>(request);
        //leaveRequest.RequestingEmployeeId = employeeId;
        leaveRequest.DateRequested = DateTime.Now;
        await _leaveRequestRepository.CreateAsync(leaveRequest);

        // Send cofirmation email
        try
        {
            var email = new EmailMessage
            {
                To = "", // Get email from employee record
                Subject = "Leave Request Submitted",
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} has been submitted successfully."
            };
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex )
        {
            //_logger.LogError($"Unable to send email for leave request submission for {employeeId} - {ex.Message}");
            // TODO: handle email exception
            throw;
        }

        return Unit.Value;
    }
}
