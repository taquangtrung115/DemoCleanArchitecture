using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.Management.Persistence.Reponsitory
{
    public class LeaveTypeReponsitory : GenericReponsitory<LeaveType>, ILeaveTypeReponsitory
    {
        private readonly LeaveManagenmentDBContext _dbContext;
        public LeaveTypeReponsitory(LeaveManagenmentDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
