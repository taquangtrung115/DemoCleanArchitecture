using HR.LeaveManagement.Application.DTO.Common;
using HR.LeaveManagement.Application.DTO.LeaveType;

namespace HR.LeaveManagement.Application.DTO.LeaveAllowcation
{
    public class LeaveAllowcationDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}