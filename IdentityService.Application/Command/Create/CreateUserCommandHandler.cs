using AutoMapper;
using Common.Application.Contracts.Persistence;
using IdentityService.Application.Contracts;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Command.Create
{
    public class RegisterUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IAsyncRepository<Users> _userRepository;
        private readonly IAsyncRepository<UserRoles> _userRoleRepository;
        private readonly IPasswordHasher _passwordHasher;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IAsyncRepository<Users> userRepository,
            IAsyncRepository<UserRoles> userRoleRepository,
            IPasswordHasher passwordHasher,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._userRepository = userRepository;
            this._userRoleRepository = userRoleRepository;
            this._passwordHasher = passwordHasher;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = _passwordHasher.HashPassword(request.Password);

            Users user = _mapper.Map<Users>(request);
            user.CreatedDate = DateTime.UtcNow;

            await _userRepository.AddAsync(user);

            if (user != null)
            {
                UserRoles usrRole = new()
                {
                    UserId = user.Id,
                    RoleId = request.RoleId
                };

                await _userRoleRepository.AddAsync(usrRole);
            }

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
