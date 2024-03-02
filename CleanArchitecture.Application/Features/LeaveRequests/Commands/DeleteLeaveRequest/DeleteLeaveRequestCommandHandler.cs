using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IAppLogger<DeleteLeaveRequestCommandHandler> _logger;
    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IAppLogger<DeleteLeaveRequestCommandHandler> logger)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = _leaveRequestRepository.GetByIdAsync(request.Id).Result;

        if (leaveRequest == null)
        {
            _logger.LogError($"LeaveRequest with id {request.Id} was not found.");
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        await _leaveRequestRepository.DeleteAsync(leaveRequest);
        _logger.LogInformation($"LeaveRequest with id {request.Id} was deleted.");

        return Unit.Value;
    }
}
