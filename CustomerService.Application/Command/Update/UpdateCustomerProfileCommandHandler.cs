using AutoMapper;
using Common.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Update
{
    public class UpdateCustomerProfileCommandHandler : IRequestHandler<UpdateCustomerProfileCommand, bool>
    {
        private readonly IAsyncRepository<CustomerProfile> _customerProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerProfileCommandHandler(IAsyncRepository<CustomerProfile> customerProfileRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._customerProfileRepository = customerProfileRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCustomerProfileCommand request, CancellationToken cancellationToken)
        {
            CustomerProfile customers = _mapper.Map<CustomerProfile>(request);

            var customerProfiles = await _customerProfileRepository.FindAsync(cust => cust.UserId == request.UserId);
            if (customerProfiles != null && customerProfiles.Any())
            {
                customers.Id = customerProfiles.FirstOrDefault().Id;
            }
            customers.LastModifiedBy = request.Email;

            //validation code 

            await _customerProfileRepository.UpdateAsync(customers);

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
