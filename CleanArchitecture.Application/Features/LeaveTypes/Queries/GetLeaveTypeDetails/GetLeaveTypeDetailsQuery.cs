using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQuery : IRequest<LeaveTypeDetailsDto>
{
    public int Id { get; set; }
}
