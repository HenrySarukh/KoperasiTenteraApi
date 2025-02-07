using KoperasiTenteraApi.Domain.Contracts;
using KoperasiTenteraApi.Domain.Entities;
using KoperasiTenteraApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KoperasiTenteraApi.Infrastructure.Persistance.Repositories
{
    public class OtpRepository : GenericRepository<Otp, long>, IOtpRepository
    {
        public OtpRepository(KoperasiTenteraContext context) : base(context)
        {
        }

        public async Task<Otp?> GetLastOtp(OtpType type, string source, string code)
        {
            return await DbSet
                .Where(otp => otp.Type == type &&
                       otp.Source == source &&
                       otp.Code == code)
                .OrderByDescending(otp => otp.CreatedAt)
                .FirstOrDefaultAsync();
        }
    }
}
