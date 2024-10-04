namespace ClaimProcessingService.Application.Command.Create
{
    public record ClaimDTO
    {
        public string ClaimType { get; init; }

        public string IncidentDetails { get; init; }

        public decimal ClaimAmount { get; init; }

        public string ClaimStatus { get; init; }

        public DateTime DateOfClaim { get; init; }
    }
}
