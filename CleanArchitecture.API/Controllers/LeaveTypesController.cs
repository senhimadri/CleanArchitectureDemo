using CleanArchitecture.Application.DTOs.LeaveType;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands;
using CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> Get()
        {
            var leavetyps = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leavetyps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(int id)
        {
            var leavetype = await _mediator.Send(new GetLeaveTypeDetailsRequest { Id = id });
            return Ok(leavetype);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDTO leavetype)
        {
            var command = new CreateLeaveTypeCommand { leavetypeDTO = leavetype };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LeaveTypeDTO leavetype)
        {
            var command = new UpdateLeaveTypeCommand { LeaveTypeDTO = leavetype };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
