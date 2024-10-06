using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationReponsitory : IGenericReponsitory<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllowcationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllowcationWithDetails();
    }
}
