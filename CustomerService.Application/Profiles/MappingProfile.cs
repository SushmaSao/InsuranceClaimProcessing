using AutoMapper;
using CustomerService.Application.Command;
using CustomerService.Application.Command.Create;
using CustomerService.Application.Command.Update;
using CustomerService.Application.Queries;
using CustomerService.Domain.Entities;

namespace CustomerService.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerProfile, ReadCustomerProfileDTO>().ReverseMap();
            CreateMap<CreateCustomerProfileCommand, CustomerProfile>().ReverseMap();
            CreateMap<UpdateCustomerProfileCommand, CustomerProfile>().ReverseMap();
            CreateMap<CreateCustomerProfileCommand, CustomerProfileDTO>().ReverseMap();
            CreateMap<UpdateCustomerProfileCommand, CustomerProfileDTO>().ReverseMap();


        }
    }
}
