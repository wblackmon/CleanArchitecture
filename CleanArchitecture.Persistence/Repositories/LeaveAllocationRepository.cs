using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(CleanArchitectureDbConext context) : base(context)
    {
    }

    public async Task AddLeaveAllocations(List<LeaveAllocation> leaveAllocations)
    {
        await _context.LeaveAllocations.AddRangeAsync(leaveAllocations);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AllocaionExists(int leaveTypeId, string employeeId, int period)
    {
        var allocationExists = await _context.LeaveAllocations.AnyAsync(
            x => x.EmployeeId == employeeId
            && x.LeaveTypeId == leaveTypeId
            && x.Period == period);

        return allocationExists;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllLeaveAllocaions()
    {
        var leaveallocations = await _context.LeaveAllocations
            .Include(x => x.LeaveType)
            .ToListAsync();

        return leaveallocations;
    }

    public async  Task<LeaveAllocation> GetLeaveAllocationByEmployeeIdAndLeaveTypeId(string employeeId, int leaveTypeId)
    {
        return await _context.LeaveAllocations.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId) ?? new LeaveAllocation();
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationById(int id)
    {
        var leaveAllocation = await _context.LeaveAllocations
            .Include(x => x.LeaveType)
            .FirstOrDefaultAsync(x => x.Id == id);

        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsByEmployee(string employeeId)
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Where(x => x.EmployeeId == employeeId)
            .Include(x => x.LeaveType)
            .ToListAsync();

        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsByEmployeeAndLeaveTypeId(string employeeId, int leaveTypeId)
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Where(x => x.EmployeeId == employeeId && x.LeaveTypeId == leaveTypeId)
            .Include(x => x.LeaveType)
            .ToListAsync();

        return leaveAllocations;
    }
}
