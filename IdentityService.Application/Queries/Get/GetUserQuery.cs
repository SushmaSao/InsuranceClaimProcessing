using MediatR;

namespace IdentityService.Application.Queries.Get
{
    public record GetUserQuery : IRequest<UserModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
