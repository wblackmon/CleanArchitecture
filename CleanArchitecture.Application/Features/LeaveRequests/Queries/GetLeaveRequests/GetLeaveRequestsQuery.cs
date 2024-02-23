using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequests;

public class GetLeaveRequestsQuery : IRequest<List<LeaveRequestsDto>>
{
    public bool IsLoggedInUser { get; set; }
}
