using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestReponsitory _leaveRequestReponsitory;
        private readonly IMapper _mapper;
        public CreateLeaveRequestCommandHandler(ILeaveRequestReponsitory leaveRequestReponsitory, IMapper mapper)
        {
            _leaveRequestReponsitory = leaveRequestReponsitory;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _leaveRequestReponsitory.Add(leaveRequest);

            return leaveRequest.ID;
        }
    }
}
