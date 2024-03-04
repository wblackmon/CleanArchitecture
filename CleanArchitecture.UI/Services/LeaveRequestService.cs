using CleanArchitecture.UI.Contracts;
using CleanArchitecture.UI.Services.Base;

namespace CleanArchitecture.UI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        public LeaveRequestService(IClient client) : base(client)
        {
        }
    }
}
