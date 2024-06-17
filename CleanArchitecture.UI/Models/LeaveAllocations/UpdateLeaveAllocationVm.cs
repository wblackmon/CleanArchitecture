using CleanArchitecture.UI.Models.LeaveTypes;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.UI.Models.LeaveAllocations
{
    public class UpdateLeaveAllocationVm
    {
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        [Range(1, 50, ErrorMessage = "Enter Valid Number")]
        public int NumberOfDays { get; set; }
        public LeaveTypeVm LeaveType { get; set; }
    }
}
