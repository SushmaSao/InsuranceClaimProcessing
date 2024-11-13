using AutoMapper;
using Common.Application.Contracts.Persistence;
using Common.Application.Contracts.UserContract;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateCustomerProfileCommandHandler : IRequestHandler<CreateCustomerProfileCommand, bool>
    {

        private readonly IAsyncCommandRepository<CustomerProfile> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        public CreateCustomerProfileCommandHandler(IAsyncCommandRepository<CustomerProfile> customerRepository, IUnitOfWork unitOfWork, IMapper mapper, ICurrentUser currentUser)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._currentUser = currentUser;
        }

        public async Task<bool> Handle(CreateCustomerProfileCommand request, CancellationToken cancellationToken)
        {
            CustomerProfile customers = _mapper.Map<CustomerProfile>(request);
            customers.Email = _currentUser.Email;

            await _customerRepository.AddAsync(customers);

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
