using MediatR;

namespace CustomerService.Application.Command.Update
{
    public record UpdateCustomerProfileCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public string Address { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Email { get; set; }
    }
}
