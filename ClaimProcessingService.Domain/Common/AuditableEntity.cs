namespace ClaimProcessingService.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; } = "Admin";
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; } = "Admin";
        public DateTime? LastModifiedDate { get; set; }

    }
}
