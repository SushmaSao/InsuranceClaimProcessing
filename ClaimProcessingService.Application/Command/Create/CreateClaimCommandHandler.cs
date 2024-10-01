using AutoMapper;
using ClaimProcessingService.Application.Command.Create;
using ClaimProcessingService.Domain.Entities;
using Common.Application.Contracts.Persistence;
using MediatR;

namespace CustomerService.Application.Command.Create
{
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, bool>
    {
        private readonly IAsyncRepository<Claim> _claimRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClaimCommandHandler(IAsyncRepository<Claim> claimRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._claimRepository = claimRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        async Task<bool> IRequestHandler<CreateClaimCommand, bool>.Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            Claim claim = _mapper.Map<Claim>(request);

            //validation code 

            await _claimRepository.AddAsync(claim);
            await _unitOfWork.CommitAsync();


            return true;
        }
    }
}
