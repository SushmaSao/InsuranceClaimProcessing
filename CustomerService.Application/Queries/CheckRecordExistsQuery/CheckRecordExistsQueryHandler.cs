using Common.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Queries
{
    public class CheckRecordExistsQueryHandler : IRequestHandler<CheckRecordExistsQuery, bool>
    {
        private readonly IAsyncRepository<CustomerProfile> _customerProfileRepository;

        public CheckRecordExistsQueryHandler(IAsyncRepository<CustomerProfile> customerProfileRepository)
        {
            _customerProfileRepository = customerProfileRepository;
        }
        public async Task<bool> Handle(CheckRecordExistsQuery request, CancellationToken cancellationToken)
        {
            var customerProfiles = await _customerProfileRepository.FindAsync(cust => cust.Email == request.Email);
            if (customerProfiles != null && customerProfiles.Any())
            {
                return true;
            }
            return false;
        }
    }
}
