using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateCustomerCommand(string firstName, string lastName, string email, string phoneNumber, string address, DateTime dateOfBirth) : IRequest<bool>
    {
        public string FirstName { get; } = firstName;

        public string LastName { get; } = lastName;

        public string Email { get; } = email;

        public string PhoneNumber { get; } = phoneNumber;

        public string Address { get; } = address;

        public DateTime DateOfBirth { get; } = dateOfBirth;
    }
}
