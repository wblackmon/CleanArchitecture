using CleanArchitecture.UI.Models.LeaveRequests;
using CleanArchitecture.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Contracts
{
    public interface ILeaveRequestService
    {
        Task<AdminLeaveRequestViewVm> GetAdminLeaveRequestList();
        Task<EmployeeLeaveRequestViewVm> GetUserLeaveRequests();
        Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVm leaveRequest);
        Task<LeaveRequestVm> GetLeaveRequest(int id);
        Task DeleteLeaveRequest(int id);
        Task<Response<Guid>> ApproveLeaveRequest(int id, bool approved);
        Task<Response<Guid>> CancelLeaveRequest(int id);
    }
}
