using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands
{
    public class DeleteLeaveAllowcationCommand : IRequest
    {
        public int ID { get; set; }
    }
}
