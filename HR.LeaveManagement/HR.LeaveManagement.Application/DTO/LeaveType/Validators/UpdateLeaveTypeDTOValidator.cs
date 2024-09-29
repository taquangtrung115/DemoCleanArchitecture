using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveType.Validators
{
    public class UpdateLeaveTypeDTOValidator : AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeDTOValidator()
        {
            Include(new ILeaveTypeDTOValidator());

            RuleFor(s => s.ID).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
