using ClaimProcessingService.Application.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClaimProcessingService.API.Controllers
{
    [Authorize]
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            createClaimCommand.UserId = Guid.Parse(userId);

            var response = await _mediator.Send(createClaimCommand);
            return Ok(response);
        }
    }
}
