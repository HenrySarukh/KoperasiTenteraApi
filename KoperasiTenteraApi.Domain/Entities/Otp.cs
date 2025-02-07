using System.ComponentModel.DataAnnotations;
using KoperasiTenteraApi.Domain.Common;
using KoperasiTenteraApi.Domain.Enums;

namespace KoperasiTenteraApi.Domain.Entities
{
    public class Otp : AuditableEntity, IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public bool Valid { get; set; }
        public required string Source { get; set; }
        public OtpType Type { get; set; }
        [StringLength(6)]
        public required string Code { get; set; }
    }
}