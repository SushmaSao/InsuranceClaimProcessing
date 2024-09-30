using IdentityService.Application.Command.Create;
using IdentityService.Application.Contracts;
using IdentityService.Application.Queries.Get;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator, IPasswordHasher passwordHasher, ITokenGenerator tokenGenerator)
        {
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
            _mediator = mediator;
        }

        [HttpPost(Name = "Signup")]
        public async Task<ActionResult> RegisterUser([FromBody] CreateUserCommand registerUserCommand)
        {
            string password = _passwordHasher.HashPassword(registerUserCommand.Password);

            registerUserCommand.Password = password;

            var response = await _mediator.Send(registerUserCommand);

            return Ok(response);
        }

        //public async Task Authenticate(GetUserQuery getUserQuery)
        //{
        //    var user = await _mediator.Send(getUserQuery);
        //    if (user == null || !_passwordHasher.VerifyPassword(getUserQuery.Password, user.Password))
        //    {
        //        throw new Exception("Invalid credentials");
        //    }

        //    // Generate JWT token with roles
        //    var token = _tokenGenerator.GenerateToken(user.Email, user);

        //    return token;
        //}


    }
}
