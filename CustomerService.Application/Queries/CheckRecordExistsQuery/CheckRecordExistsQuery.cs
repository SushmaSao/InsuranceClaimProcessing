using MediatR;

namespace CustomerService.Application.Queries
{
    public record CheckRecordExistsQuery(string Email) : IRequest<bool>;
}
