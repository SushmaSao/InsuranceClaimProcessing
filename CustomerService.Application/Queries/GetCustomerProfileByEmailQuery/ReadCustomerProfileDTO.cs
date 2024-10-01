namespace CustomerService.Application.Queries
{
    public record ReadCustomerProfileDTO(string FirstName, string LastName, string Email, string PhoneNumber, DateTime DateOfBirth, string Address);
}
