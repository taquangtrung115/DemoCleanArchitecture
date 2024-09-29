using HR.LeaveManagement.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveType
{
    public class LeaveTypeDTO : BaseDTO, ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
