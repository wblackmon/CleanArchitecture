using CleanArchitecture.UI.Contracts;
using CleanArchitecture.UI.Services.Base;

namespace CleanArchitecture.UI.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(IClient client) : base(client)
        {
        }

        public async Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId)
        {
            try
            {
                var response = new Response<Guid>();
                CreateLeaveAllocationCommand command = new CreateLeaveAllocationCommand { LeaveTypeId = leaveTypeId };
                //await _client.LeaveAllocationsPOSTAsync(command);
                return new Response<Guid> { Message = "Leave Allocation Created Successfully", Success = true };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
