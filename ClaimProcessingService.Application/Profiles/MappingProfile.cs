using AutoMapper;
using ClaimProcessingService.Application.Command.Create;
using ClaimProcessingService.Domain.Entities;

namespace CustomerService.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Claim, CreateClaimCommand>().ReverseMap();
            CreateMap<CreateClaimCommand, ClaimDTO>().ReverseMap();
        }
    }
}
