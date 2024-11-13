using Common.Application.FunctionalExtensions;
using CustomerService.Application.Command;

namespace CustomerService.Application.Services
{
    public interface ICustomerProfileService
    {
        Task<Result<CustomerProfileDTO>> CreateOrUpdateProfile(CustomerProfileDTO profileDTO);
    }
}
