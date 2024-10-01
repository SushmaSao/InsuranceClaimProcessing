using CustomerService.Application.Command;

namespace CustomerService.Application.Services
{
    public interface ICustomerProfileService
    {
        Task CreateOrUpdateProfile(string email, Guid userId, CustomerProfileDTO profileDTO);
    }
}
