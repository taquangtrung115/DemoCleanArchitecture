using HR.LeaveManagement.Application.DTO.LeaveAllowcation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Queries
{
    public class GetLeaveAllowcationRequest : IRequest<List<LeaveAllowcationDTO>>
    {

    }
}
