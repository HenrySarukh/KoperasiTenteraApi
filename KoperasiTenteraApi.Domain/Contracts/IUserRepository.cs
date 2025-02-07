using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Domain.Contracts
{
    public interface IUserRepository : IGenericRepository<User, long>
    {
        Task<User?> GetByOtpSource(OtpType otpType, string source);
        Task<User?> GetByIC(string ic);

    }
}
