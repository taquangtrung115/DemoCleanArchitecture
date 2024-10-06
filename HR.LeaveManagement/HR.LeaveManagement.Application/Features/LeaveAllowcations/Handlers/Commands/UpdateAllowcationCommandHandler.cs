using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveAllowcation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
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
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;

        public UpdateAllowcationCommandHandler(ILeaveAllocationReponsitory leaveAllocationReponsitory
            , ILeaveTypeReponsitory leaveTypeReponsitory
            , IMapper mapper)
        {
            _leaveAllocationReponsitory = leaveAllocationReponsitory;
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAllowcationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAllowcationDTOValidator(_leaveTypeReponsitory);

            var validationResult = await validator.ValidateAsync(request.LeaveAllowcationDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveAllowcation = await _leaveAllocationReponsitory.Get(request.LeaveAllowcationDTO.ID);

            _mapper.Map(request.LeaveAllowcationDTO, leaveAllowcation);

            await _leaveAllocationReponsitory.Update(leaveAllowcation);

            return Unit.Value;
        }
    }
}