using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Contracts
{
    public interface IPhoneOtpService
    {
        Task SendOtp(string mobileNumber, string otp);
    }
}
