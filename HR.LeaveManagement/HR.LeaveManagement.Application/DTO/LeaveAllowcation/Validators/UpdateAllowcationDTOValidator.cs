using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveAllowcation.Validators
{
    public class UpdateAllowcationDTOValidator: AbstractValidator<UpdateLeaveAllowcationDTO>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        public UpdateAllowcationDTOValidator(ILeaveTypeReponsitory leaveTypeReponsitory)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            Include(new ILeaveAllowcationDTOValidator(_leaveTypeReponsitory));

            RuleFor(s => s.ID).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
