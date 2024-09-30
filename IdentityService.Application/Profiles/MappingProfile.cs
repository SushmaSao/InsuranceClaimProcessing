using AutoMapper;
using IdentityService.Application.Command.Create;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, CreateUserCommand>().ReverseMap();
        }
    }
}
