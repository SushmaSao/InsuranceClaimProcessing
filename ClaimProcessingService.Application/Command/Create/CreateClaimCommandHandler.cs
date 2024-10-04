using AutoMapper;
using ClaimProcessingService.Application.Command.Create;
using ClaimProcessingService.Domain.Entities;
using Common.Application.Contracts.Persistence;
using MediatR;
using System.Security.Claims;

namespace CustomerService.Application.Command.Create
{
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, bool>
    {
        private readonly IAsyncRepository<ClaimProcessingService.Domain.Entities.Claim> _claimRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClaimCommandHandler(IAsyncRepository<ClaimProcessingService.Domain.Entities.Claim> claimRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._claimRepository = claimRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        async Task<bool> IRequestHandler<CreateClaimCommand, bool>.Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            ClaimProcessingService.Domain.Entities.Claim claim = _mapper.Map<ClaimProcessingService.Domain.Entities.Claim>(request);
            claim.CreatedBy = request.Email;
            claim.LastModifiedBy = string.Empty;

            //validation code 

            await _claimRepository.AddAsync(claim);
            await _unitOfWork.CommitAsync();


            return true;
        }
    }
}
