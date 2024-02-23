using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
{
    public Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
