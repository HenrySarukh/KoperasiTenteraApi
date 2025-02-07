using KoperasiTenteraApi.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Infrastructure.Mailing
{
    public class SomeMailingService : IMailingService
    {
        public Task SendEmail(string email, string otp)
        {
            // Some implementation
            return Task.FromResult(true);
        }
    }
}
