using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;

public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
{
}
