namespace CleanArchitecture.UI.Models.LeaveAllocations
{
    public class ViewLeaveAllocationVm
    {
        public string EmployeeId { get; set; }
        public List<LeaveAllocationVm> LeaveAllocations { get; set; }
    }
}
