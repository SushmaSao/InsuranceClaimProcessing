using AutoMapper;
using Common.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IAsyncRepository<Customer> customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        async Task<bool> IRequestHandler<CreateCustomerCommand, bool>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customers = _mapper.Map<Customer>(request);

            //validation code 

            await _customerRepository.AddAsync(customers);

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
