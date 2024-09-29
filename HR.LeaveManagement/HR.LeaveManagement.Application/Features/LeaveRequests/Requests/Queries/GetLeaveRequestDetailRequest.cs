using HR.LeaveManagement.Application.DTO.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDTO>
    {
        public int ID { get; set; }
    }
}
