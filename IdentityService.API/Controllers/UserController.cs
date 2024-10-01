using IdentityService.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using IdentityService.Application.Queries.Get;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMediator _mediator;

        public UserController(ITokenGenerator tokenGenerator, IMediator mediator)
        {
            _tokenGenerator = tokenGenerator;
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
