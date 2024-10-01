using MediatR;

namespace CustomerService.Application.Queries
{
    public record GetCustomerProfileByEmailQuery(string Email) : IRequest<ReadCustomerProfileDTO>;
}
