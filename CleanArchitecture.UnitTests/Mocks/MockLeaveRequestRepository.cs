using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.UnitTests.Mocks
{
    public class MockLeaveRequestRepository 
    {
        public static Mock<ILeaveRequestRepository> GetMockLeaveTypeRepository()
        {
            var leaveRequests = new List<LeaveRequest>
            {
                new LeaveRequest { Id = 1, LeaveTypeId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), DateRequested = DateTime.Now, RequestingEmployeeId = "1", Approved = false, Cancelled = false },
                new LeaveRequest { Id = 2, LeaveTypeId = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), DateRequested = DateTime.Now, RequestingEmployeeId = "2", Approved = false, Cancelled = false },
                new LeaveRequest { Id = 3, LeaveTypeId = 3, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10), DateRequested = DateTime.Now, RequestingEmployeeId = "3", Approved = false, Cancelled = false }
            };
            var mockRepo = new Mock<ILeaveRequestRepository>();

            mockRepo.Setup(repo => repo.GetAllLeaveRequests()).ReturnsAsync(leaveRequests);

            mockRepo.Setup(repo => repo.GetLeaveRequestByid(It.IsAny<int>()))
                .ReturnsAsync((int id) => leaveRequests.FirstOrDefault(lr => lr.Id == id));

            mockRepo.Setup(repo => repo.GetLeaveRequestsByEmployeeId(It.IsAny<string>()))
                .ReturnsAsync((string employeeId) => leaveRequests.Where(lr => lr.RequestingEmployeeId == employeeId).ToList());
  

            return mockRepo;
        }
    }
}
