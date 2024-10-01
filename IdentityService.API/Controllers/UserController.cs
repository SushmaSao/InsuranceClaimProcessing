using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]

    [ApiController]

    public class UserController : ControllerBase
    {
    }
}
