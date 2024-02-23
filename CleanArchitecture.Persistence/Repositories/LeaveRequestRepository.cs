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

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(CleanArchitectureDbConext context) : base(context)
    {

    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsByEmployeeId(string employeeId)
    {
        var leaveRequests = await _context.LeaveRequests
            .Where(x => x.RequestingEmployeeId == employeeId)
            .Include(q => q.LeaveType)  
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetAllLeaveRequests()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(x => x.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<LeaveRequest?> GetLeaveRequestByid(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Where(x => x.Id == id)
            .Include(x => x.LeaveType)
            .FirstOrDefaultAsync();

        return leaveRequest;
    }
}
