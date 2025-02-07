using ErrorOr;
using KoperasiTenteraApi.Domain.Contracts;
using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Infrastructure.Persistance.Repositories
{
    public class UserRepository : GenericRepository<User, long>, IUserRepository
    {
        public UserRepository(KoperasiTenteraContext context) : base(context)
        {
        }

        public async Task<User?> GetByIC(string ic)
        {
            return await DbSet.Where(user => user.IC == ic).FirstOrDefaultAsync();
        }

        public async Task<User?> GetByOtpSource(OtpType otpType, string source)
        {
            var user = otpType switch
            {
                OtpType.Phone => await DbSet.Where(user => user.MobileNumber == source).FirstOrDefaultAsync(),
                OtpType.Email => await DbSet.Where(user => user.Email == source).FirstOrDefaultAsync(),
                _ => null
            };

            return user;
        }
    }
}
