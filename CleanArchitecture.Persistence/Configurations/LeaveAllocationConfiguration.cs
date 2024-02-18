using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Configurations;

public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
{
    // Copilot: i need to add some test data here
    public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
    {
        var fixedDate = DateTime.Now.AddDays(-1); // Use a fixed date for seeding

        builder.HasData(
            new LeaveAllocation
            {
                Id = 1,
                NumberOfDays = 10,
                DateCreated = fixedDate,
                DateModified = fixedDate,
                Period = 2021,
                EmployeeId = "1",
                LeaveTypeId = 1 // Ensure this ID exists in LeaveTypes
            },
            new LeaveAllocation
            {
                Id = 2,
                NumberOfDays = 10,
                DateCreated = fixedDate,
                DateModified = fixedDate,
                Period = 2021,
                EmployeeId = "2",
                LeaveTypeId = 2 // Ensure this ID exists in LeaveTypes
            }
        );
    }
}
