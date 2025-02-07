using KoperasiTenteraApi.Application.Contracts;
using KoperasiTenteraApi.Domain.Contracts;
using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;
using KoperasiTenteraApi.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Services
{
    // I will not add otp limit logic as a lot of otp services have it build in
    public class OtpService : IOtpService
    {
        private readonly IOtpRepository _otpRepository;
        private readonly IMailingService _mailingService;
        private readonly IPhoneOtpService _phoneOtpService;

        public OtpService(
            IOtpRepository otpRepository,
            IMailingService mailingService,
            IPhoneOtpService phoneOtpService)
        {
            _otpRepository = otpRepository;
            _phoneOtpService = phoneOtpService;
            _mailingService = mailingService;
        }

        string GenerateOtp()
        {
            string randomOtp = "123456";

            // Check if prod send real otp
            //string environment = Environment.GetEnvironmentVariable("ENV");

            //if (environment.Equals("prod", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    randomOtp = new Random().Next(100000, 999999).ToString();
            //}

            return randomOtp;
        }

        public async Task SendOtp(OtpType type, string source)
        {
            var code = GenerateOtp();

            if (type == OtpType.Email)
            {
                await _mailingService.SendEmail(code, source);
            }
            else
            {
                await _phoneOtpService.SendOtp(code, source);
            }

            await _otpRepository.Add(new Otp
            {
                Code = code,
                Type = type,
                Source = source,
                Valid = true
            });
        }

        public async Task<bool> CheckOtp(OtpType type, string source, string code)
        {
            var otp = await _otpRepository.GetLastOtp(type, source, code);

            if (otp == null || !otp.Valid)
            {
                return false;
            }

            var valid = OtpValidate(otp.CreatedAt);
            if (!valid)
            {
                return false;
            }

            otp.Valid = false;
            _otpRepository.Update(otp);

            return true;
        }

        public bool OtpValidate(DateTime createdAt)
        {
            createdAt = createdAt.AddMinutes(Constants.OtpLifeTime);
            return createdAt < DateTime.Now; ;
        }
    }
}
