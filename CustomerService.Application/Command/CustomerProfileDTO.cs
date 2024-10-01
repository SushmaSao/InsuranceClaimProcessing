namespace CustomerService.Application.Command
{
    public record CustomerProfileDTO
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public string Address { get; init; }
        public DateTime DateOfBirth { get; init; }
    }

}
