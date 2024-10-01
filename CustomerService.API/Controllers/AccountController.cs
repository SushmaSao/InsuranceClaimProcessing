using CustomerService.Application.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {
        }

        [HttpGet(Name = "Welcome")]
        public async Task<ActionResult> UpdateCustomerInfo()
        {
            var task = Task.FromResult("Hello World");
            return Ok(await task);
        }


    }
}
