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
    public  class MockLeaveAllocationRepository
    {
        public static Mock<ILeaveAllocationRepository> GetMockLeaveAllocationRepository()
        {
            var leaveAllocations = new List<LeaveAllocation>
            {
                new LeaveAllocation { Id = 1, DateCreated = DateTime.Now, DateModified = null, EmployeeId = "1", LeaveTypeId = 1, NumberOfDays = 20, Period = 2022 },
                new LeaveAllocation { Id = 2, DateCreated = DateTime.Now, DateModified = null, EmployeeId = "2", LeaveTypeId = 2, NumberOfDays = 30, Period = 2022 },
                new LeaveAllocation { Id = 3, DateCreated = DateTime.Now, DateModified = null, EmployeeId = "3", LeaveTypeId = 3, NumberOfDays = 30, Period = 2022 }
            };

            var mockRepo = new Mock<ILeaveAllocationRepository>();


            mockRepo.Setup(repo => repo.GetLeaveAllocationById(It.IsAny<int>()))
                .ReturnsAsync((int id) => leaveAllocations.FirstOrDefault(la => la.Id == id));

            mockRepo.Setup(repo => repo.GetLeaveAllLeaveAllocaions()).ReturnsAsync(leaveAllocations);

            mockRepo.Setup(repo => repo.GetLeaveAllocationsByEmployeeAndLeaveTypeId(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync((string employeeId, int leaveTypeId) => leaveAllocations.Where(la => la.EmployeeId == employeeId && la.LeaveTypeId == leaveTypeId).ToList());

            mockRepo.Setup(repo => repo.GetLeaveAllocationsByEmployee(It.IsAny<string>()))
                .ReturnsAsync((string employeeId) => leaveAllocations.Where(la => la.EmployeeId == employeeId).ToList());

            mockRepo.Setup(repo => repo.AllocaionExists(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync((int leaveTypeId, string employeeId, int period) => leaveAllocations.Any(
                    la => la.LeaveTypeId == leaveTypeId && la.EmployeeId == employeeId && la.Period == period));

            var leaveAllocationsToAdd = new List<LeaveAllocation>
            {
                new LeaveAllocation { Id = 4, DateCreated = DateTime.Now, DateModified = null, EmployeeId = "4", LeaveTypeId = 1, NumberOfDays = 20, Period = 2022 },
                new LeaveAllocation { Id = 5, DateCreated = DateTime.Now, DateModified = null, EmployeeId = "5", LeaveTypeId = 2, NumberOfDays = 30, Period = 2022 },
                new LeaveAllocation { Id = 6, DateCreated = DateTime.Now, DateModified = null, EmployeeId = "6", LeaveTypeId = 3, NumberOfDays = 30, Period = 2022 }
            };

            mockRepo.Setup(repo => repo.AddLeaveAllocations(It.IsAny<List<LeaveAllocation>>()))
                .Returns((List<LeaveAllocation> leaveAllocations) =>
                {
                    leaveAllocations.AddRange(leaveAllocationsToAdd);
                    return Task.CompletedTask;
                });

            mockRepo.Setup(repo => repo.GetLeaveAllocationByEmployeeIdAndLeaveTypeId(It.IsAny<string>(), It.IsAny<int>()))
                .Returns((string employeeId, int leaveTypeId) => leaveAllocations.FirstOrDefault(la => la.EmployeeId == employeeId && la.LeaveTypeId == leaveTypeId));

            return mockRepo;
        }
    }
}
