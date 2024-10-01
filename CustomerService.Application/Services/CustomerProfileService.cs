using AutoMapper;
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

        public CustomerProfileService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task CreateOrUpdateProfile(string email, Guid userId, CustomerProfileDTO profileDTO)
        {
            CheckRecordExistsQuery checkRecordExistsQuery = new CheckRecordExistsQuery(email);

            bool isExist = await _mediator.Send(checkRecordExistsQuery);
            if (!isExist)
            {
                CreateCustomerProfileCommand createCommand = _mapper.Map<CreateCustomerProfileCommand>(profileDTO);
                createCommand.Email = email;
                createCommand.UserId = userId;

                await _mediator.Send(createCommand);
            }
            else
            {
                UpdateCustomerProfileCommand createCommand = _mapper.Map<UpdateCustomerProfileCommand>(profileDTO);
                createCommand.Email = email;
                createCommand.UserId = userId;

                await _mediator.Send(createCommand);

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
