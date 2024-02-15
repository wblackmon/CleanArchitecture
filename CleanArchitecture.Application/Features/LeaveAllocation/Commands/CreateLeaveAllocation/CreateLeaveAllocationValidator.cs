using CleanArchitecture.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            //RuleFor(p => p.NumberOfDays)
            //    .GreaterThan(0)
            //    .MustAsync(LeaveTypeExists);

        }
        private async Task<bool> LeaveTypeExists(int leaveTypeId, CancellationToken token)
        {
            //return await _leaveTypeRepository.IsLeaveTypeUnique(leaveTypeId);
            return true;
        }

    }
}
