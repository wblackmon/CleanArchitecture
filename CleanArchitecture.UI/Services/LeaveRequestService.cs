using AutoMapper;
using Blazored.LocalStorage;
using CleanArchitecture.UI.Contracts;
using CleanArchitecture.UI.Services.Base;
using CleanArchitecture.UI.Models.LeaveRequests;

namespace CleanArchitecture.UI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    private readonly IMapper _mapper;
    public LeaveRequestService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client)
    {
        _mapper = mapper;
    }

    public Task<Response<Guid>> ApproveLeaveRequest(int id, bool approved)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Guid>> CancelLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVm leaveRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AdminLeaveRequestViewVm> GetAdminLeaveRequestList()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveRequestVm> GetLeaveRequest(int id)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeLeaveRequestViewVm> GetUserLeaveRequests()
    {
        throw new NotImplementedException();
    }
}
