using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class ILeaveRequestDTOValidator : AbstractValidator<ILeaveRequestDTO>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;

        public ILeaveRequestDTOValidator(ILeaveTypeReponsitory leaveTypeReponsitory)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;

            RuleFor(s => s.StartDate)
              .LessThan(s => s.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(s => s.EndDate)
              .GreaterThan(s => s.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(s => s.LeaveTypeID)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExits = await _leaveTypeReponsitory.Exists(id);
                    return !leaveTypeExits;
                }).WithMessage("{PropertyName} does not exits.");
        }
    }
}
