using MediatR;

namespace ClaimProcessingService.Application.Command.Create
{
    public class CreateClaimCommand(Guid userId, string claimType, string incidentDetails, decimal claimAmount, string claimStatus, DateTime dateofClaim) : IRequest<bool>
    {
        public Guid UserId { get; set; } = userId;

        public string ClaimType { get; } = claimType;

        public string IncidentDetails { get; } = incidentDetails;

        public decimal ClaimAmount { get; } = claimAmount;

        public string ClaimStatus { get; } = claimStatus;

        public DateTime DateOfClaim { get; } = dateofClaim;
    }
}
