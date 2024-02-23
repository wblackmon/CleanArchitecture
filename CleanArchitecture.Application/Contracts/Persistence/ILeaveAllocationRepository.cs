using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation?> GetLeaveAllocationById(int id);
        Task<List<LeaveAllocation>> GetLeaveAllLeaveAllocaions();
        Task<List<LeaveAllocation>> GetLeaveAllocationsByEmployeeAndLeaveTypeId(string employeeId, int leaveTypeId);
        Task<List<LeaveAllocation>> GetLeaveAllocationsByEmployee(string employeeId);
        Task<bool> AllocaionExists(int leaveTypeId, string employeeId, int period);
        Task AddLeaveAllocations(List<LeaveAllocation> leaveAllocations);
        Task<LeaveAllocation> GetLeaveAllocationByEmployeeIdAndLeaveTypeId(string employeeId, int leaveTypeId);
    }
}
