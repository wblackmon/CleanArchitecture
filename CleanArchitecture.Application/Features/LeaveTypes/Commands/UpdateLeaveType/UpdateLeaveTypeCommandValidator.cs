using CleanArchitecture.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveTypes.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveTypeExists);


        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} must be greater than .")
            .LessThan(100).WithMessage(string.Format("{PropertyName} must be less than 100."));

        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeExists(int id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType != null;
    }
}
