using IdentityService.Application.Command.Create;
using IdentityService.Application.Contracts;
using IdentityService.Application.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator, ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
            _mediator = mediator;
        }

        [HttpPost("Signup")]
        public async Task<ActionResult> RegisterUser([FromBody] CreateUserCommand registerUserCommand)
        {
            var response = await _mediator.Send(registerUserCommand);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Authenticate([FromBody] GetUserQuery getUserQuery)
        {
            var user = await _mediator.Send(getUserQuery);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            // Generate JWT token with roles
            var token = _tokenGenerator.GenerateToken(user.Email, new List<string>() { user.RoleId?.ToString() });

            return Ok(token);
        }


    }
}
