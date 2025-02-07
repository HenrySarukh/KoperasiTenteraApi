using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;

namespace KoperasiTenteraApi.Application.Contracts
{
    public interface IOtpService
    {
        public Task SendOtp(OtpType type, string source);
        public Task<bool> CheckOtp(OtpType type, string source, string code);

    }
}
