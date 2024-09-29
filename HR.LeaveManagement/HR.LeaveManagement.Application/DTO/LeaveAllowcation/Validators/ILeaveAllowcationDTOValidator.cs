using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveAllowcation.Validators
{
    public class ILeaveAllowcationDTOValidator : AbstractValidator<ILeaveAllowcationDTO>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        public ILeaveAllowcationDTOValidator(ILeaveTypeReponsitory leaveTypeReponsitory)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            RuleFor(s => s.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(s => s.Period).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(s => s.LeaveTypeID).GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExits = await _leaveTypeReponsitory.Exists(id);
                    return !leaveTypeExits;
                }).WithMessage("{PropertyName} does not exits.");
        }
    }
}
