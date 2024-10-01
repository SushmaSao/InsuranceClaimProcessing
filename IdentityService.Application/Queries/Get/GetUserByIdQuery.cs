using MediatR;

namespace IdentityService.Application.Queries.Get
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<GetUserDTO>;
}
