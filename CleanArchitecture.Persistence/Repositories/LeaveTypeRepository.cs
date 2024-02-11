using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(CleanArchitectureDbConext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            var matches = await _context.LeaveTypes.AnyAsync(lt => lt.Name.Equals(name));
            return matches;
        }
    }
}
