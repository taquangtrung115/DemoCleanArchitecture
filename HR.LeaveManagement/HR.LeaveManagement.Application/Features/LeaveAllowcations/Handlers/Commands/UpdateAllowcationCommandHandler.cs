using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Handlers.Commands
{
    public class UpdateAllowcationCommandHandler : IRequestHandler<UpdateAllowcationCommand, Unit>
    {
        private readonly ILeaveAllocationReponsitory _leaveAllocationReponsitory;
        private readonly IMapper _mapper;
        public UpdateAllowcationCommandHandler(ILeaveAllocationReponsitory leaveAllocationReponsitory, IMapper mapper)
        {
            _leaveAllocationReponsitory = leaveAllocationReponsitory;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAllowcationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllowcation = await _leaveAllocationReponsitory.Get(request.LeaveAllowcationDTO.ID);

            _mapper.Map(request.LeaveAllowcationDTO, leaveAllowcation);

            await _leaveAllocationReponsitory.Update(leaveAllowcation);

            return Unit.Value;
        }
    }
}
