using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Reponsitories
{
    public class LeaveAllowcationReponsitory : GenericReponsitory<LeaveAllocation>, ILeaveAllocationReponsitory
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveAllowcationReponsitory(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveAllocation> GetLeaveAllowcationWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveAllocations.Include(s => s.LeaveType).FirstOrDefaultAsync(s => s.ID == id);
            return leaveRequest;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllowcationWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveAllocations.Include(s => s.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }
}
