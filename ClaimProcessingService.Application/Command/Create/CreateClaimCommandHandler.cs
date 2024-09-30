using AutoMapper;
using ClaimProcessingService.Application.Command.Create;
using ClaimProcessingService.Application.Contracts.Persistence;
using ClaimProcessingService.Domain.Entities;
using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, bool>
    {
        private readonly IAsyncRepository<Claim> _claimRepository;
        private readonly IMapper _mapper;

        public CreateClaimCommandHandler(IAsyncRepository<Claim> claimRepository, IMapper mapper)
        {
            this._claimRepository = claimRepository;
            this._mapper = mapper;
        }

        async Task<bool> IRequestHandler<CreateClaimCommand, bool>.Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            Claim claim = _mapper.Map<Claim>(request);

            //validation code 

            claim = await _claimRepository.AddAsync(claim);

            return true;
        }
    }
}
