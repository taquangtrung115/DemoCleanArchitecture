using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestReponsitory _leaveRequestReponsitory;
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestReponsitory leaveRequestReponsitory
            , ILeaveTypeReponsitory leaveTypeReponsitory
            , IMapper mapper)
        {
            _leaveRequestReponsitory = leaveRequestReponsitory;
            _mapper = mapper;
            _leaveTypeReponsitory = leaveTypeReponsitory;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestValidator(_leaveTypeReponsitory);

            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveRequest = await _leaveRequestReponsitory.Get(request.ID);
            if (request.LeaveRequestDTO != null)
            {
                _mapper.Map(request.LeaveRequestDTO, leaveRequest);

                await _leaveRequestReponsitory.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDTO != null)
            {
                await _leaveRequestReponsitory.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDTO.Approved);
            }

            return Unit.Value;
        }
    }
}
