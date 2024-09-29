using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveRequest.Validators;
using HR.LeaveManagement.Application.DTO.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestReponsitory _leaveRequestReponsitory;
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;
        public CreateLeaveRequestCommandHandler(ILeaveRequestReponsitory leaveRequestReponsitory
            , ILeaveTypeReponsitory leaveTypeReponsitory
            , IMapper mapper)
        {
            _leaveRequestReponsitory = leaveRequestReponsitory;
            _mapper = mapper;
            _leaveTypeReponsitory = leaveTypeReponsitory;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateLeaveRequestValidator(_leaveTypeReponsitory);

            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (validationResult.IsValid == false)
                return new BaseCommandResponse(0, false, validationResult.Errors.Select(s => s.ErrorMessage).ToList());

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _leaveRequestReponsitory.Add(leaveRequest);

            return new BaseCommandResponse(leaveRequest.ID, false);
        }
    }
}
