using AutoMapper;
using Common.Application.Contracts.Persistence;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IAsyncRepository<Users> _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IAsyncRepository<Users> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            UserModel? usrModel = null;

            var user = await _userRepository.FindAsync(usr => usr.Email == request.Email && usr.Password == request.Password);
            if (user != null)
            {
                usrModel = _mapper.Map<UserModel>(user);
                return usrModel;
            }

            return usrModel;
        }
    }
}
