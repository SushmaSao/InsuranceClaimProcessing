using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateCustomerProfileCommand : IRequest<bool>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public string Address { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
    }
}
