using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommand : IRequest<Unit>
{
    public string RequestComments { get; set; } = string.Empty;
}
