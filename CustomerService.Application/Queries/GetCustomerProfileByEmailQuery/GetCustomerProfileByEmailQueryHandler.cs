using AutoMapper;
using Common.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Queries
{
    internal class GetCustomerProfileByEmailQueryHandler : IRequestHandler<GetCustomerProfileByEmailQuery, ReadCustomerProfileDTO>
    {
        private readonly IAsyncRepository<CustomerProfile> _customerProfileRepository;
        private readonly IMapper _mapper;

        public GetCustomerProfileByEmailQueryHandler(IAsyncRepository<CustomerProfile> customerProfileRepository, IMapper mapper)
        {
            _customerProfileRepository = customerProfileRepository;
            _mapper = mapper;
        }

        public async Task<ReadCustomerProfileDTO> Handle(GetCustomerProfileByEmailQuery request, CancellationToken cancellationToken)
        {
            var customerProfiles = await _customerProfileRepository.FindAsync(cust => cust.Email == request.Email);
            if (customerProfiles != null && customerProfiles.Any())
            {
                return _mapper.Map<ReadCustomerProfileDTO>(customerProfiles.FirstOrDefault());
            }
            return null;
        }
    }
}
