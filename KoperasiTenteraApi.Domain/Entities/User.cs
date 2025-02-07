using KoperasiTenteraApi.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace KoperasiTenteraApi.Domain.Entities
{
    public class User : AuditableEntity, IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public required string Name { get; set; }
        [StringLength(12)]
        public required string IC { get; set; }
        public required string MobileNumber { get; set; }
        public required string Email { get; set; }
    }
}