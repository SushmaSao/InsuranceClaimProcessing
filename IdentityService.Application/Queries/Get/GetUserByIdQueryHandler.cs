using AutoMapper;
using Common.Application.Contracts.Persistence;
using IdentityService.Application.Contracts;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Queries.Get
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserDTO>
    {
        private readonly IAsyncRepository<Users> _userRepository;
        private readonly IAsyncRepository<UserRoles> _userRoleRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IAsyncRepository<Users> userRepository,
            IAsyncRepository<UserRoles> userRolesRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRolesRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user != null)
            {
                //Fetch UserRoles
                var usrRoleRepo = await _userRoleRepository.FindAsync(rol => rol.UserId == user.Id);
                
                GetUserDTO userDTO = _mapper.Map<GetUserDTO>(user);

                userDTO.UserId = request.UserId;
                userDTO.RoleId=usrRoleRepo.FirstOrDefault()?.RoleId;


                return userDTO;
            }

            return null;

        }
    }
}
