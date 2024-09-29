using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDTO>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;
        public GetLeaveTypeDetailRequestHandler(ILeaveTypeReponsitory leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeReponsitory.Get(request.ID);
            return _mapper.Map<LeaveTypeDTO>(leaveType);
        }
    }
}
