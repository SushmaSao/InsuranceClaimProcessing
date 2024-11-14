using AutoMapper;
using Common.Application.Contracts.UserContract;
using Common.Application.FunctionalExtensions;
using CustomerService.Application.Command;
using CustomerService.Application.Command.Create;
using CustomerService.Application.Command.Update;
using CustomerService.Application.Queries;
using MediatR;

namespace CustomerService.Application.Services
{
    internal class CustomerProfileService : ICustomerProfileService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        public CustomerProfileService(IMediator mediator, IMapper mapper, ICurrentUser currentUser)
        {
            this._mediator = mediator;
            this._mapper = mapper;
            this._currentUser = currentUser;
        }

        public async Task<Result<CustomerProfileDTO>> CreateOrUpdateProfile(CustomerProfileDTO profileDTO)
        {
            CheckRecordExistsQuery checkRecordExistsQuery = new CheckRecordExistsQuery(_currentUser.Email);

            bool isExist = await _mediator.Send(checkRecordExistsQuery);
            if (!isExist)
            {
                CreateCustomerProfileCommand createCommand = _mapper.Map<CreateCustomerProfileCommand>(profileDTO);

                await _mediator.Send(createCommand);
                return Result.Success<CustomerProfileDTO>(profileDTO);
            }
            else
            {
                UpdateCustomerProfileCommand createCommand = _mapper.Map<UpdateCustomerProfileCommand>(profileDTO);

                return await _mediator.Send(createCommand);


            }

        }

        public async Task GetCustomerProfile(string email)
        {
            CheckRecordExistsQuery checkRecordExistsQuery = new CheckRecordExistsQuery(email);

            bool isExist = await _mediator.Send(checkRecordExistsQuery);
            if (isExist)
            {
            }
            else
            {
            }
        }
    }
}
