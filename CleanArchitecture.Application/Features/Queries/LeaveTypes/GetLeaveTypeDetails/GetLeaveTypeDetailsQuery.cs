using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Queries.LeaveTypes.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQuery : IRequest<GetLeaveTypeDetailsDto>
{
    public int Id { get; set; }
}
