using Common.Application.FunctionalExtensions;
using MediatR;

namespace CustomerService.Application.Command.Update
{
    public record UpdateCustomerProfileCommand : IRequest<Result<CustomerProfileDTO>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
