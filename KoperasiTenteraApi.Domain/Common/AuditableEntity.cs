namespace KoperasiTenteraApi.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        // it must be User type
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        // it must be User type
        public string? UpdatedBy { get; set; }
    }
}
