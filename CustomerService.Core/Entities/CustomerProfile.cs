using CustomerService.Domain.Common;

namespace CustomerService.Domain.Entities
{
    public class CustomerProfile : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address
        {
            get;
            set;
        }

        public DateTime DateOfBirth { get; set; }
    }
}
