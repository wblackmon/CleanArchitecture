using CleanArchitecture.UI.Models.LeaveAllocations;

namespace CleanArchitecture.UI.Models.LeaveRequests;

public class EmployeeLeaveRequestViewVm
{
    public List<LeaveAllocationVm> LeaveAllocations { get; set; } = new List<LeaveAllocationVm>();
    public List<LeaveRequestVm> LeaveRequests { get; set; } = new List<LeaveRequestVm>();
}
