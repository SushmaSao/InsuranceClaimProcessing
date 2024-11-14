using AutoMapper;
using Common.Application.Contracts.Persistence;
using Common.Application.Contracts.UserContract;
using Common.Application.FunctionalExtensions;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Update
{
    public class UpdateCustomerProfileCommandHandler : IRequestHandler<UpdateCustomerProfileCommand, Result<CustomerProfileDTO>>
    {
        private readonly IAsyncCommandRepository<CustomerProfile> _customerProfileRepository;
        private readonly IAsyncQueryRepository<CustomerProfile> _customerProfileReadRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly ICurrentUser _currentUser;


        public UpdateCustomerProfileCommandHandler(IAsyncCommandRepository<CustomerProfile> customerProfileRepository,
            IAsyncQueryRepository<CustomerProfile> customerProfileReadRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper, ICurrentUser currentUser)
        {
            this._customerProfileRepository = customerProfileRepository;
            _customerProfileReadRepository = customerProfileReadRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<Result<CustomerProfileDTO>> Handle(UpdateCustomerProfileCommand request, CancellationToken cancellationToken)
        {
            var customerProfiles = await _customerProfileReadRepository.FindAsync(cust => cust.UserId == _currentUser.UserId);

            if (customerProfiles != null && customerProfiles.Any())
            {
                CustomerProfile? customers = customerProfiles.FirstOrDefault();

                customers.Address = request.Address;
                customers.PhoneNumber = request.PhoneNumber;
                customers.FirstName = request.FirstName;
                customers.LastName = request.LastName;
                customers.DateOfBirth = request.DateOfBirth;

                await _customerProfileRepository.UpdateAsync(customers);

                var val = await _unitOfWork.CommitAsync();

                CustomerProfileDTO returnVal = _mapper.Map<CustomerProfileDTO>(customers);

                return Result.Success<CustomerProfileDTO>(returnVal);
            }

            return Result.Fail<CustomerProfileDTO>("Customer does not exists");

        }
    }
}
