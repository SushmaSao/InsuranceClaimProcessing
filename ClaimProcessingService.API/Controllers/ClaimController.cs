using ClaimProcessingService.Application.Command.Create;
using ClaimProcessingService.Application.Services;
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
        private readonly IClaimService _claimService;
        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpPost(Name = "AddClaim")]
        public async Task<ActionResult> Create([FromBody] ClaimDTO claimDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var email = User.FindFirstValue(ClaimTypes.Email);

            var response = await _claimService.CreateClaim(email, Guid.Parse(userId), claimDTO);
            return Ok(response);
        }
    }
}
