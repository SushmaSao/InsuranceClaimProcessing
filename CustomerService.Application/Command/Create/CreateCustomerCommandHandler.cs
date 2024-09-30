using AutoMapper;
using CustomerService.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IAsyncRepository<Customer> customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        async Task<bool> IRequestHandler<CreateCustomerCommand, bool>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customers = _mapper.Map<Customer>(request);

            //validation code 

            customers = await _customerRepository.AddAsync(customers);

            return true;
        }
    }
}
