
using ClaimProcessingService.Domain.Common;

namespace ClaimProcessingService.Domain.Entities
{
    public class Claim : AuditableEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string ClaimType { get; set; }
        public string IncidentDetails { get; set; }
        public decimal ClaimAmount { get; set; }
        public string ClaimStatus { get; set; } = "Pending";
        public DateTime DateOfClaim { get; set; } = DateTime.Now;
    }
}