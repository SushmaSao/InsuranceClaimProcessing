using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CustomerService.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProfileController : ControllerBase
    {
        public CustomerProfileController()
        {

        }

        [HttpGet(Name = "Info")]
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            return Ok("HEllo");
        }
    }
}
