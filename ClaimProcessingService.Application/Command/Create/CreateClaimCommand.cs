using MediatR;

namespace ClaimProcessingService.Application.Command.Create
{
    public class CreateClaimCommand(int customerId, string claimType, string incidentDetails, decimal claimAmount, string claimStatus, DateTime dateofClaim) : IRequest<bool>
    {
        public int CustomerId { get; } = customerId;

        public string ClaimType { get; } = claimType;

        public string IncidentDetails { get; } = incidentDetails;

        public decimal ClaimAmount { get; } = claimAmount;

        public string ClaimStatus { get; } = claimStatus;

        public DateTime DateOfClaim { get; } = dateofClaim;
    }
}
