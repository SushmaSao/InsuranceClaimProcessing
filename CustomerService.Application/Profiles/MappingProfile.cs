using AutoMapper;
using CustomerService.Application.Command.Create;
using CustomerService.Domain.Entities;

namespace CustomerService.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerProfile, CreateCustomerCommand>().ReverseMap();
        }
    }
}
