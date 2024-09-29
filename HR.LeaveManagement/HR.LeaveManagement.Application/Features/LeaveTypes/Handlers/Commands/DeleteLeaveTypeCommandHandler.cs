using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeReponsitory leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeReponsitory.Get(request.ID);

            if (leaveType == null)
                throw new NotFoundException(nameof(leaveType), request.ID);

            await _leaveTypeReponsitory.Delete(leaveType);

            return Unit.Value;

        }
    }
}
