using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveType
{
    public class CreateLeaveTypeDTO : ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
