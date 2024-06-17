using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetail;

public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDetailDto>
{
    public int Id { get; set; }
}
