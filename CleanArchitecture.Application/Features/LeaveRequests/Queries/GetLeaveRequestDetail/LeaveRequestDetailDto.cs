using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;
using CleanArchitecture.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequestDetail;

public class LeaveRequestDetailDto
{
    public int Id { get; set; }
    public Employee Employee { get; set; } = new Employee();
    public DateTime StartDate { get; set; } = new DateTime();
    public DateTime EndDate { get; set; }
    public string RequestingEmployeeId { get; set; } = string.Empty;
    public LeaveTypeDto LeaveType { get; set; } = new LeaveTypeDto();
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; } = string.Empty;
    public DateTime? DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}
