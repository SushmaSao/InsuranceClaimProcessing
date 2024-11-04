using IdentityService.Application.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            GetUserByIdQuery getUserByIdQuery = new(Guid.Parse(userId));

            var response = await _mediator.Send(getUserByIdQuery);
            return Ok(response);
        }

    }
}
