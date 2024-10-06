using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveAllowcation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllowcations.Handlers.Commands
{
    public class CreateLeaveAllowcationCommandHandler : IRequestHandler<CreateLeaveAllowcationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationReponsitory _leaveAllocationReponsitory;
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;
        public CreateLeaveAllowcationCommandHandler(ILeaveAllocationReponsitory leaveAllocationReponsitory
            , ILeaveTypeReponsitory leaveTypeReponsitory
            , IMapper mapper)
        {
            _leaveAllocationReponsitory = leaveAllocationReponsitory;
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveAllowcationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAllowcationValidator(_leaveTypeReponsitory);

            var validationResult = await validator.ValidateAsync(request.LeaveAllowcationDTO);

            if (validationResult.IsValid == false)
            {
               return new BaseCommandResponse(0, false, validationResult.Errors.Select(s => s.ErrorMessage).ToList());
            }

            var leaveAllowcation = _mapper.Map<LeaveAllocation>(request.LeaveAllowcationDTO);

            leaveAllowcation = await _leaveAllocationReponsitory.Add(leaveAllowcation);

            return new BaseCommandResponse(leaveAllowcation.ID, true);
        }
    }
}
