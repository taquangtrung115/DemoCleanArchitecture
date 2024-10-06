using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        public UpdateLeaveRequestValidator(ILeaveTypeReponsitory leaveTypeReponsitory)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;

            Include(new ILeaveRequestDTOValidator(_leaveTypeReponsitory));

            RuleFor(s => s.ID).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
