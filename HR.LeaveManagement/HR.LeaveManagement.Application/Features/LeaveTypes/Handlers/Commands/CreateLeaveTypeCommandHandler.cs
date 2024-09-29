using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
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

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeReponsitory leaveTypeReponsitory, IMapper mapper)
        {
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateLeaveTypeDTOValidator();

            var validationResult = await validator.ValidateAsync(request.LeaveTypeDTO);

            if (validationResult.IsValid == false)
                return new BaseCommandResponse(0, false, validationResult.Errors.Select(s => s.ErrorMessage).ToList());

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDTO);
            leaveType = await _leaveTypeReponsitory.Add(leaveType);

            return new BaseCommandResponse(leaveType.ID, true);
        }
    }
}
