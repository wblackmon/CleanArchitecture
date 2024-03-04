using AutoMapper;
using CleanArchitecture.UI.Contracts;
using CleanArchitecture.UI.Models.LeaveTypes;
using CleanArchitecture.UI.Services.Base;

namespace CleanArchitecture.UI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        public LeaveTypeService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVm leaveType)
        {
            try
            {
                var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);
                return new Response<Guid> { Message = "Leave Type Created Successfully", Success = true };
            }
            catch (ApiException apiException)
            {

                return ConvertApiExceptions<Guid>(apiException);
            }
        }

        public async Task<Response<Guid>> DeleteLeaveType(int id)
        {
            try
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<Guid> { Message = "Leave Type Deleted Successfully", Success = true };
            }
            catch (ApiException apiException)
            {
                return ConvertApiExceptions<Guid>(apiException);
            }
        }

        public async Task<LeaveTypeVm> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _client.LeaveTypesGETAsync(id);
            var leaveTypeVm = _mapper.Map<LeaveTypeVm>(leaveType);
            return leaveTypeVm;
        }

        public async Task<List<LeaveTypeVm>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            var leaveTypeVms = _mapper.Map<List<LeaveTypeVm>>(leaveTypes);
            return leaveTypeVms;
        }

        public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVm leaveType)
        {
            try
            {
                var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPUTAsync(id.ToString(), updateLeaveTypeCommand);
                return new Response<Guid> { Message = "Leave Type Updated Successfully", Success = true };
            }
            catch (ApiException apiException)
            {
                return ConvertApiExceptions<Guid>(apiException);
            }
        }
    }
}
