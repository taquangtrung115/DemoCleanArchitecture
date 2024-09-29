using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class LeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDTO>
    {
        private readonly ILeaveRequestReponsitory _leaveRequestReponsitory;
        private readonly IMapper _mapper;
        public LeaveRequestDetailRequestHandler(ILeaveRequestReponsitory leaveRequestReponsitory, IMapper mapper)
        {
            _leaveRequestReponsitory = leaveRequestReponsitory;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestReponsitory.GetLeaveRequestWithDetails(request.ID);

            return _mapper.Map<LeaveRequestDTO>(leaveRequest);
        }
    }
}
