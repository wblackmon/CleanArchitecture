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

namespace CleanArchitecture.Application.Features.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<DeleteLeaveTypeCommandHandler> _logger;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IAppLogger<DeleteLeaveTypeCommandHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the entity from the database
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // Verify that the entity exists
        if (leaveType == null)
        {
            _logger.LogWarning("Leave Type does not exist");
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        // Delete the entity from the database
        await _leaveTypeRepository.DeleteAsync(leaveType);

        // Return the result
        return Unit.Value;
    }
}
