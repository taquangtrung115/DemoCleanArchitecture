using HR.LeaveManagement.Application.DTO.LeaveAllowcation;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands
{
    public class CreateLeaveAllowcationCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllowcationDTO LeaveAllowcationDTO { get; set; }
    }
}
