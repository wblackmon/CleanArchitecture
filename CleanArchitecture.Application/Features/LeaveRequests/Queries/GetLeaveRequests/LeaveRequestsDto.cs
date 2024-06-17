using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;
using CleanArchitecture.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveRequests.Queries.GetLeaveRequests;

public class LeaveRequestsDto
{
    public int Id { get; set; }
    public Employee Employee { get; set; } = new Employee();
    public string RequestingEmployeeId { get; set; } = string.Empty;
    public LeaveTypeDto LeaveType { get; set; } = new LeaveTypeDto();
    public DateTime DateRequested { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool? Approved { get; set; }
    public bool? Cancelled { get; set; }
}
