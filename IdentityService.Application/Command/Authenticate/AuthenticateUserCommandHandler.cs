using Common.Application.Contracts.Persistence;
using IdentityService.Application.Contracts;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Command.Authenticate
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IAsyncCommandRepository<Users> _userRepository;
        private readonly IAsyncCommandRepository<UserRoles> _userRoleRepository;
        private readonly IAsyncQueryRepository<Users> _userReadRepository;
        private readonly IAsyncQueryRepository<UserRoles> _userRoleReadRepository;

        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticateUserCommandHandler(IAsyncCommandRepository<Users> userRepository,
            IAsyncCommandRepository<UserRoles> usrRoleRepository,
            IAsyncQueryRepository<Users> userReadRepository,
            IAsyncQueryRepository<UserRoles> userRoleReadRepository,
            IPasswordHasher passwordHasher,
            ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _userRoleRepository = usrRoleRepository;
            _userReadRepository = userReadRepository;
            _userRoleReadRepository = userRoleReadRepository;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            string token = string.Empty;

            var user = await _userReadRepository.FindAsync(usr => usr.Email == request.Email);

            if (user != null && user.Any())
            {
                var usrDetails = user.FirstOrDefault();

                //Validate Password
                if (user == null || !_passwordHasher.VerifyPassword(request.Password, usrDetails.Password))
                {
                    throw new Exception("Invalid credentials");
                }

                //Fetch UserRoles
                var usrRoleRepo = await _userRoleReadRepository.FindAsync(rol => rol.UserId == usrDetails.Id);


                // Generate JWT token with roles
                token = _tokenGenerator.GenerateToken(usrDetails.Id, usrDetails.Email, usrRoleRepo.Select(a => a.Id.ToString()));

            }

            return token;
        }
    }
}
