using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<List<LeaveRequest>> GetAllLeaveRequests();
    Task<LeaveRequest?> GetLeaveRequestByid(int id);
    Task<List<LeaveRequest>> GetLeaveRequestByEmployeeId(string employeeId);
}
