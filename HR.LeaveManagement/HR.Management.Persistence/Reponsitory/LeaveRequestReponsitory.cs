using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HR.Management.Persistence.Reponsitory
{
    public class LeaveRequestReponsitory : GenericReponsitory<LeaveRequest>, ILeaveRequestReponsitory
    {
        private readonly LeaveManagenmentDBContext _dbContext;
        public LeaveRequestReponsitory(LeaveManagenmentDBContext dbContext) : base(dbContext)
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
            var leaveRequest = await _dbContext.LeaveRequest.Include(s => s.LeaveType).FirstOrDefaultAsync(s => s.ID == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequest.Include(s => s.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }
}
