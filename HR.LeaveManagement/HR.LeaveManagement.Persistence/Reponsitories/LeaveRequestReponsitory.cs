using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Reponsitories
{
    public class LeaveRequestReponsitory : GenericReponsitory<LeaveRequest>, ILeaveRequestReponsitory
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveRequestReponsitory(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified; ;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests.Include(s => s.LeaveType).FirstOrDefaultAsync(s => s.ID == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests.Include(s => s.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }
}
