using KoperasiTenteraApi.Application.Contracts;

namespace KoperasiTenteraApi.Infrastructure.PhoneOtp
{
    public class SomeOtpService : IPhoneOtpService
    {
        public Task SendOtp(string mobileNumber, string otp)
        {
            // Some implementation
            return Task.FromResult(true);
        }
    }
}
