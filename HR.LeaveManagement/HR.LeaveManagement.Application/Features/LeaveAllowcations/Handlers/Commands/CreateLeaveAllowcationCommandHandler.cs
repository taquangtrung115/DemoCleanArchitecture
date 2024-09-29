using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Handlers.Commands
{
    public class CreateLeaveAllowcationCommandHandler : IRequestHandler<CreateLeaveAllowcationCommand, int>
    {
        private readonly ILeaveAllocationReponsitory _leaveAllocationReponsitory;
        private readonly IMapper _mapper;
        public CreateLeaveAllowcationCommandHandler(ILeaveAllocationReponsitory leaveAllocationReponsitory, IMapper mapper)
        {
            _leaveAllocationReponsitory = leaveAllocationReponsitory;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllowcationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllowcation = _mapper.Map<LeaveAllocation>(request.LeaveAllowcationDTO);

            leaveAllowcation = await _leaveAllocationReponsitory.Add(leaveAllowcation);

            return leaveAllowcation.ID;
        }
    }
}
