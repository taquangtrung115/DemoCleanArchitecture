using AutoMapper;
using HR.LeaveManagement.Application.DTO.LeaveRequest.Validators;
using HR.LeaveManagement.Application.DTO.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
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
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestReponsitory _leaveRequestReponsitory;
        private readonly ILeaveTypeReponsitory _leaveTypeReponsitory;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public CreateLeaveRequestCommandHandler(ILeaveRequestReponsitory leaveRequestReponsitory
            , ILeaveTypeReponsitory leaveTypeReponsitory
            , IMapper mapper
            , IEmailSender emailSender
            )
        {
            _leaveRequestReponsitory = leaveRequestReponsitory;
            _mapper = mapper;
            _leaveTypeReponsitory = leaveTypeReponsitory;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateLeaveRequestValidator(_leaveTypeReponsitory);

            var validationResult = await validator.ValidateAsync(request.LeaveRequestDTO);

            if (validationResult.IsValid == false)
                return new BaseCommandResponse(0, false, validationResult.Errors.Select(s => s.ErrorMessage).ToList());

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDTO);
            leaveRequest = await _leaveRequestReponsitory.Add(leaveRequest);

            var email = new Email
            {
                To = "trungtaquang.it@gmail.com",
                Body = $"You leave request for {request.LeaveRequestDTO.StartDate:D} to {request.LeaveRequestDTO.EndDate:D} has been submmited,",
                Subject = "Leave Request Submmited"
            }; 

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {

            }

            return new BaseCommandResponse(leaveRequest.ID, false);
        }
    }
}
