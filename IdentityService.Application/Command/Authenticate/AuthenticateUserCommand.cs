using MediatR;

namespace IdentityService.Application.Command.Authenticate
{
    public record AuthenticateUserCommand(string Email, string Password) : IRequest<string>;
}
