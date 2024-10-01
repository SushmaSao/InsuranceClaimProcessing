using IdentityService.Application.Command.Authenticate;
using IdentityService.Application.Command.Create;
using IdentityService.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Signup")]
        public async Task<ActionResult> RegisterUser([FromBody] CreateUserCommand registerUserCommand)
        {
            var response = await _mediator.Send(registerUserCommand);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateUserCommand authenticateUserCommand)
        {
            string token = await _mediator.Send(authenticateUserCommand);

            return Ok(token);
        }


    }
}
