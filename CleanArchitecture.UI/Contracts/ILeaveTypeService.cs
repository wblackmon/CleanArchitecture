using CleanArchitecture.UI.Models.LeaveTypes;
using CleanArchitecture.UI.Services;
using CleanArchitecture.UI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ILeaveTypeService
{
    Task<List<LeaveTypeVm>> GetLeaveTypes();
    Task<LeaveTypeVm> GetLeaveTypeDetails(int id);
    Task<Response<Guid>> CreateLeaveType(LeaveTypeVm leaveType);
    Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVm leaveType);
    Task<Response<Guid>> DeleteLeaveType(int id);
}
