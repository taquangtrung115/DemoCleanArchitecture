﻿using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Handlers.Commands
{
    public class DeleteLeaveAllowcationCommandHandler : IRequestHandler<DeleteLeaveAllowcationCommand>
    {
        private readonly ILeaveAllocationReponsitory _leaveAllocationReponsitory;
        private readonly IMapper _mapper;
        public DeleteLeaveAllowcationCommandHandler(ILeaveAllocationReponsitory leaveAllocationReponsitory, IMapper mapper)
        {
            _leaveAllocationReponsitory = leaveAllocationReponsitory;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveAllowcationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllowcation = await _leaveAllocationReponsitory.Get(request.ID);

            if (leaveAllowcation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.ID);

            await _leaveAllocationReponsitory.Delete(leaveAllowcation);

            return Unit.Value;
        }
    }
}
