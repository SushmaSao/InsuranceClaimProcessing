using Common.Application.FunctionalExtensions;
using CustomerService.Application.Command;
using CustomerService.Application.Queries;
using CustomerService.Application.Services;
using MediatR;
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
        private readonly ICustomerProfileService _customerProfileService;
        private readonly IMediator _mediator;
        public CustomerProfileController(ICustomerProfileService customerProfileService, IMediator mediator)
        {
            this._customerProfileService = customerProfileService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (email == null)
            {
                return Unauthorized();
            }

            GetCustomerProfileByEmailQuery getCustomerProfileByEmailQuery = new GetCustomerProfileByEmailQuery(email);

            var result = await _mediator.Send(getCustomerProfileByEmailQuery);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(CustomerProfileDTO customerProfileDTO)
        {
            Result<CustomerProfileDTO> results = await _customerProfileService.CreateOrUpdateProfile(customerProfileDTO);
            return results.IsSuccess ? Ok(results) : NotFound(results.Error);
        }
    }
}
