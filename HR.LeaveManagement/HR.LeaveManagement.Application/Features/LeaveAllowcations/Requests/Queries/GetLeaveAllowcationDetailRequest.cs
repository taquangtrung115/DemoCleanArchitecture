using HR.LeaveManagement.Application.DTO.LeaveAllowcation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Queries
{
    public class GetLeaveAllowcationDetailRequest : IRequest<LeaveAllowcationDTO>
    {
        public int ID { get; set; }
    }
}
