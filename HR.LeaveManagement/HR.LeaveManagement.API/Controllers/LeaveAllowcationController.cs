using HR.LeaveManagement.Application.DTO.LeaveAllowcation;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllowcations.Requests.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllowcationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveAllowcationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveAllowcationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllowcationDTO>>> Get()
        {
            var leaveAllowcations = await _mediator.Send(new GetLeaveAllowcationRequest());
            return Ok(leaveAllowcations);
        }

        // GET api/<LeaveAllowcationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllowcationDTO>> Get(int id)
        {
            var leaveAllowcation = await _mediator.Send(new GetLeaveAllowcationDetailRequest { ID = id });
            return Ok(leaveAllowcation);
        }

        // POST api/<LeaveAllowcationController>
        [HttpPost]
        public async Task<ActionResult<CreateLeaveAllowcationDTO>> Post([FromBody] CreateLeaveAllowcationDTO leaveAllowcation)
        {
            var command = new CreateLeaveAllowcationCommand { LeaveAllowcationDTO = leaveAllowcation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveAllowcationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllowcationDTO leaveAllowcation)
        {
            var command = new UpdateAllowcationCommand { LeaveAllowcationDTO = leaveAllowcation, ID = id};
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllowcationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllowcationCommand { ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
