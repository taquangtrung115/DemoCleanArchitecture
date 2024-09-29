using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveAllowcation.Validators
{
    public class CreateAllowcationValidator : AbstractValidator<CreateLeaveAllowcationDTO>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        public CreateAllowcationValidator(ILeaveTypeReponsitory leaveTypeReponsitory)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            Include(new ILeaveAllowcationDTOValidator(_leaveTypeReponsitory));
        }
    }
}
