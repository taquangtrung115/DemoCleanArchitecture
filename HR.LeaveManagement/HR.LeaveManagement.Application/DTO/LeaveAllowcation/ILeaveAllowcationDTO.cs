using HR.LeaveManagement.Application.DTO.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveAllowcation
{
    public interface ILeaveAllowcationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}
