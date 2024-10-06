using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Reponsitories
{
    public class LeaveTypeReponsitory : GenericReponsitory<LeaveType>, ILeaveTypeReponsitory
    {
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveTypeReponsitory(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
