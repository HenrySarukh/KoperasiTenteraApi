using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;

namespace KoperasiTenteraApi.Domain.Contracts
{
    public interface IOtpRepository : IGenericRepository<Otp, long>
    {
        Task<Otp?> GetLastOtp(OtpType type, string source, string code);
    }
}
