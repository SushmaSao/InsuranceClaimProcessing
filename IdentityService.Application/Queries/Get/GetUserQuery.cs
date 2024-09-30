using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Queries.Get
{
    public class GetUserQuery(string email, string password) : IRequest<UserModel>
    {
        public string Email { get; } = email;
        public string Password { get; } = password;

        public Roles Roles { get; set; }
    }
}
