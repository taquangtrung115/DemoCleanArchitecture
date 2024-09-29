using HR.LeaveManagement.Application.DTO.LeaveType;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDTO LeaveTypeDTO { get; set; }
    }
}
