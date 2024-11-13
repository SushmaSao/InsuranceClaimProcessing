using MediatR;

namespace CustomerService.Application.Command.Create
{
    public record CreateCustomerProfileCommand : IRequest<bool>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public DateTime DateOfBirth { get; }
    }
}
