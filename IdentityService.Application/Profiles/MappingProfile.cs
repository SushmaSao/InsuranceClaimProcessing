using AutoMapper;
using IdentityService.Application.Command.Create;
using IdentityService.Application.Queries.Get;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Command
            CreateMap<Users, CreateUserCommand>().ReverseMap();

            CreateMap<Users, GetUserDTO>().ReverseMap();


        }
    }
}
