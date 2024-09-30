﻿using MediatR;

namespace IdentityService.Application.Command.Create
{
    public record CreateUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }


}
