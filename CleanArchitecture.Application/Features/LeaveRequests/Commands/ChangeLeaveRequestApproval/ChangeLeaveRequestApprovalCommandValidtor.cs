using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandValidtor : AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestApprovalCommandValidtor()
        {
            RuleFor(p => p.Approved)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }

    }
}
