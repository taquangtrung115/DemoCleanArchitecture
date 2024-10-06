using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTO.LeaveRequest.Validators
{
    public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        public CreateLeaveRequestValidator(ILeaveTypeReponsitory leaveTypeReponsitory)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            Include(new ILeaveRequestDTOValidator(_leaveTypeReponsitory));
        }
    }
}
