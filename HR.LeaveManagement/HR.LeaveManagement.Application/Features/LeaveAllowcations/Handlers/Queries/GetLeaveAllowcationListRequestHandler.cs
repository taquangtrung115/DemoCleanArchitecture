using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveAllowcation;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Queries;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Handlers.Queries
{
    public class GetLeaveAllowcationRequestHandler : IRequestHandler<GetLeaveAllowcationRequest, List<LeaveAllowcationDTO>>
    {
        private readonly ILeaveAllocationReponsitory _leaveAllocationReponsitory;
        private readonly IMapper _mapper;
        public GetLeaveAllowcationRequestHandler(ILeaveAllocationReponsitory leaveAllocationReponsitory, IMapper mapper)
        {
            _leaveAllocationReponsitory = leaveAllocationReponsitory;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllowcationDTO>> Handle(GetLeaveAllowcationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllowcations = await _leaveAllocationReponsitory.GetAll();
            return _mapper.Map<List<LeaveAllowcationDTO>>(leaveAllowcations);
        }
    }
}
