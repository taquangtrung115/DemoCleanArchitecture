using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveAllowcation;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Handlers.Queries
{
    public class GetLeaveAllowcationDetailRequestHandler : IRequestHandler<GetLeaveAllowcationDetailRequest, LeaveAllowcationDTO>
    {
        private readonly ILeaveAllocationReponsitory _leaveAllocationReponsitory;
        private readonly IMapper _mapper;
        public GetLeaveAllowcationDetailRequestHandler(ILeaveAllocationReponsitory leaveAllocationReponsitory, IMapper mapper)
        {
            _leaveAllocationReponsitory = leaveAllocationReponsitory;
            _mapper = mapper;
        }
        public async Task<LeaveAllowcationDTO> Handle(GetLeaveAllowcationDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllowcation = await _leaveAllocationReponsitory.GetLeaveAllowcationWithDetails(request.ID);

            return _mapper.Map<LeaveAllowcationDTO>(leaveAllowcation);
        }
    }
}
