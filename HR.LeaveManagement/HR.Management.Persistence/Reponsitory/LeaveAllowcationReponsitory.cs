using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.Management.Persistence.Reponsitory
{
    public class LeaveAllowcationReponsitory : GenericReponsitory<LeaveAllocation>, ILeaveAllocationReponsitory
    {
        private readonly LeaveManagenmentDBContext _dbContext;
        public LeaveAllowcationReponsitory(LeaveManagenmentDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveAllocation> GetLeaveAllowcationWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveAllowcation.Include(s => s.LeaveType).FirstOrDefaultAsync(s => s.ID == id);
            return leaveRequest;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllowcationWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveAllowcation.Include(s => s.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }
}
