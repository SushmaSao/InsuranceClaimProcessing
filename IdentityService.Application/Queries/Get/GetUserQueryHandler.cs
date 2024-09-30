using AutoMapper;
using Common.Application.Contracts.Persistence;
using IdentityService.Application.Contracts;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IAsyncRepository<Users> _userRepository;
        private readonly IAsyncRepository<UserRoles> _userRoleRepository;
        private readonly IPasswordHasher _passwordHasher;

        private readonly IMapper _mapper;

        public GetUserQueryHandler(IAsyncRepository<Users> userRepository, IAsyncRepository<UserRoles> usrRoleRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = usrRoleRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            UserModel? usrModel = null;

            var user = await _userRepository.FindAsync(usr => usr.Email == request.Email);

            if (user != null && user.Any())
            {
                var usrDetails = user.FirstOrDefault();

                //Validate Password
                if (user == null || !_passwordHasher.VerifyPassword(request.Password, usrDetails.Password))
                {
                    throw new Exception("Invalid credentials");
                }


                var usrRoleRepo = await _userRoleRepository.FindAsync(rol => rol.UserId == usrDetails.Id);
                usrModel = _mapper.Map<UserModel>(usrDetails);
                usrModel.RoleId = usrRoleRepo.FirstOrDefault()?.RoleId;

                return usrModel;
            }

            return usrModel;
        }
    }
}
