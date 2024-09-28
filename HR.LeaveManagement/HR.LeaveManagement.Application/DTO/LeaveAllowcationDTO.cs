using HR.LeaveManagement.Application.DTO.Common;

namespace HR.LeaveManagement.Application.DTO
{
    public class LeaveAllowcationDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public int Period { get; set; }
    }
}