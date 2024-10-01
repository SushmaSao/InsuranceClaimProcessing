using Common.Application.Contracts.Persistence;
using IdentityService.Application.Contracts;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Command.Authenticate
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IAsyncRepository<Users> _userRepository;
        private readonly IAsyncRepository<UserRoles> _userRoleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticateUserCommandHandler(IAsyncRepository<Users> userRepository,
            IAsyncRepository<UserRoles> usrRoleRepository,
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _userRoleRepository = usrRoleRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            string token = string.Empty;

            var user = await _userRepository.FindAsync(usr => usr.Email == request.Email);

            if (user != null && user.Any())
            {
                var usrDetails = user.FirstOrDefault();

                //Validate Password
                if (user == null || !_passwordHasher.VerifyPassword(request.Password, usrDetails.Password))
                {
                    throw new Exception("Invalid credentials");
                }

                //Fetch UserRoles
                var usrRoleRepo = await _userRoleRepository.FindAsync(rol => rol.UserId == usrDetails.Id);


                // Generate JWT token with roles
                token = _tokenGenerator.GenerateToken(usrDetails.Id, new List<string>() { usrRoleRepo.FirstOrDefault()?.RoleId.ToString() });

            }

            return token;
        }
    }
}
