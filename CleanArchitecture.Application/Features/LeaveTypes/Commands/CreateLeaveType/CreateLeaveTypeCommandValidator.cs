using CleanArchitecture.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveTypes.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} must be greater than .")
            .LessThan(100).WithMessage(string.Format("{PropertyName} must be less than 100."));

        RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type exists.");

        _leaveTypeRepository = leaveTypeRepository;
    }

    private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
