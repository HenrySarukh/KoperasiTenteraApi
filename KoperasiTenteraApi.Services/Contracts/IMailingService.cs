using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Application.Contracts
{
    public interface IMailingService
    {
        Task SendEmail(string email, string otp);
    }
}
