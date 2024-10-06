using HR.LeaveManagement.Application.DTO.LeaveAllowcation;
using HR.LeaveManagement.Application.DTO.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator mediator;
        public LeaveRequestController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDTO>>> Get()
        {
            var leaveRequests = await mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(int id)
        {
            var leaveRequests = await mediator.Send(new GetLeaveRequestDetailRequest { ID = id });
            return Ok(leaveRequests);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        [HttpPost]
        public async Task<ActionResult<CreateLeaveRequestDTO>> Post([FromBody] CreateLeaveRequestDTO leaveRequest)
        {
            var command = new CreateLeaveRequestCommand { LeaveRequestDTO = leaveRequest };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDTO leaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { LeaveRequestDTO = leaveRequest, ID = id };
            await mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { ID = id };
            await mediator.Send(command);
            return NoContent();
        }
        // PUT api/<LeaveRequestController>/5
        [HttpPut("changeappval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id,[FromBody] ChangeLeaveRequestApprovalDTO leaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovalDTO = leaveRequest, ID = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
