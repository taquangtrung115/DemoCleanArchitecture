using HR.LeaveManagement.Application.DTO.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveRequest
{
    public interface ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeID { get; set; }
    }
}
