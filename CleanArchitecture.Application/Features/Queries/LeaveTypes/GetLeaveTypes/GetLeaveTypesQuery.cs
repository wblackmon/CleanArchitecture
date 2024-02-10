using MediatR;

namespace CleanArchitecture.Application.Features.Queries.LeaveTypes.GetLeaveTypes;

public class GetLeaveTypesQuery : IRequest<IEnumerable<LeaveTypeDto>>
{
}
