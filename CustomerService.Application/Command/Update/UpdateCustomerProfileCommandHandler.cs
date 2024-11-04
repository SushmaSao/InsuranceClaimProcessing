using AutoMapper;
using Common.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Update
{
    public class UpdateCustomerProfileCommandHandler : IRequestHandler<UpdateCustomerProfileCommand, bool>
    {
        private readonly IAsyncCommandRepository<CustomerProfile> _customerProfileRepository;
        private readonly IAsyncQueryRepository<CustomerProfile> _customerProfileReadRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerProfileCommandHandler(IAsyncCommandRepository<CustomerProfile> customerProfileRepository,
            IAsyncQueryRepository<CustomerProfile> customerProfileReadRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._customerProfileRepository = customerProfileRepository;
            _customerProfileReadRepository = customerProfileReadRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCustomerProfileCommand request, CancellationToken cancellationToken)
        {
            CustomerProfile customers;

            var customerProfiles = await _customerProfileReadRepository.FindAsync(cust => cust.UserId == request.UserId);
            if (customerProfiles != null && customerProfiles.Any())
            {
                var custdata = customerProfiles.FirstOrDefault();

                customers = _mapper.Map<CustomerProfile>(request);

                customers.Id = custdata.Id;
                customers.CreatedBy = custdata.CreatedBy;
                customers.CreatedDate = custdata.CreatedDate;

                //validation code 

                await _customerProfileRepository.UpdateAsync(customers);

                await _unitOfWork.CommitAsync();

                return true;
            }
            return false;

        }
    }
}
