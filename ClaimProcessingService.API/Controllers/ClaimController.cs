using ClaimProcessingService.Application.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClaimProcessingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClaimController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddClaim")]
        public async Task<ActionResult> Create([FromBody] CreateClaimCommand createClaimCommand)
        {
            var response = await _mediator.Send(createClaimCommand);
            return Ok(response);
        }
    }
}
