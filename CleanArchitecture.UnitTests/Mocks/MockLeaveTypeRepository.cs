using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType { Id = 1, Name = "Vacation", DefaultDays = 10, DateCreated = DateTime.Now, DateModified = null },
                new LeaveType { Id = 2, Name = "Sick", DefaultDays = 10, DateCreated = DateTime.Now, DateModified = null },
                new LeaveType { Id = 3, Name = "Maternity", DefaultDays = 10, DateCreated = DateTime.Now, DateModified = null }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();


            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => leaveTypes.FirstOrDefault(lt => lt.Id == id));

            mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<LeaveType>()))
                .Returns((LeaveType leaveType) =>
                {
                    leaveTypes.Add(leaveType);
                    return Task.CompletedTask;
                });

            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<LeaveType>()))
                .Returns(Task.CompletedTask);

            mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<LeaveType>()))
                .Returns(Task.CompletedTask);

            // Copilot TODO - Mock IsLeaveTypeUnique
            mockRepo.Setup(repo => repo.IsLeaveTypeUnique(It.IsAny<string>()))
                .ReturnsAsync((string name) => {
                    return !leaveTypes.Any(lt => lt.Name == name);
                });

            return mockRepo;

        }
    }
}
