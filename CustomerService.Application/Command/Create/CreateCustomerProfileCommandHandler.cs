using AutoMapper;
using Common.Application.Contracts.Persistence;
using CustomerService.Application.Validator;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateCustomerProfileCommandHandler : IRequestHandler<CreateCustomerProfileCommand, bool>
    {
        private readonly IAsyncCommandRepository<CustomerProfile> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerProfileCommandHandler(IAsyncCommandRepository<CustomerProfile> customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> Handle(CreateCustomerProfileCommand request, CancellationToken cancellationToken)
        {


            CustomerProfile customers = _mapper.Map<CustomerProfile>(request);

            customers.CreatedBy = request.Email;
            customers.LastModifiedBy = string.Empty;

            //validation code 

            await _customerRepository.AddAsync(customers);

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
