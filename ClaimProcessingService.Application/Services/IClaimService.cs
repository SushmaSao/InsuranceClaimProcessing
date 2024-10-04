using ClaimProcessingService.Application.Command.Create;

namespace ClaimProcessingService.Application.Services
{
    public interface IClaimService
    {
        Task<bool> CreateClaim(string email, Guid userId, ClaimDTO claimDTO);
    }
}
