using AutoMapper;
using ClaimProcessingService.Application.Command.Create;
using MediatR;

namespace ClaimProcessingService.Application.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClaimService(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }
        public async Task<bool> CreateClaim(string email, Guid userId, ClaimDTO claimDTO)
        {
            var createClaimCommand = _mapper.Map<CreateClaimCommand>(claimDTO);
            createClaimCommand.Email = email;
            createClaimCommand.UserId=userId;

            return await _mediator.Send(createClaimCommand);
        }
    }
}
