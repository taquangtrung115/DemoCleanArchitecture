using HR.LeaveManagement.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveAllowcation
{
    public class CreateLeaveAllowcationDTO : ILeaveAllowcationDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}
