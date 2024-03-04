using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace CleanArchitecture.IntegrationTests
{
    public class CleanArchitectureDbContextTests
    {
        private readonly CleanArchitectureDbConext _context;
        public CleanArchitectureDbContextTests()
        {
            var options = new DbContextOptionsBuilder<CleanArchitectureDbConext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new CleanArchitectureDbConext(options);
        }
        [Fact]
        public async void Save_SetDates()
        {
            // Arrange: Create a new LeaveType
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Leave Type"
            };

            // Act: Add the LeaveType to the context
            await _context.LeaveTypes.AddAsync(leaveType);
            // Save the changes
            await _context.SaveChangesAsync();

            // Assert: The DateCreated and DateModified properties should be set
            leaveType.DateCreated.ShouldNotBeNull();
            leaveType.DateModified.ShouldNotBeNull();

        }
    }
}