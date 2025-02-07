using KoperasiTenteraApi.Application.Contracts;
using KoperasiTenteraApi.Domain.Contracts;
using KoperasiTenteraApi.Infrastructure.Mailing;
using KoperasiTenteraApi.Infrastructure.PhoneOtp;
using KoperasiTenteraApi.Infrastructure.Persistance;
using KoperasiTenteraApi.Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KoperasiTenteraApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KoperasiTenteraContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("KoperasiTentera")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOtpRepository, OtpRepository>();

            services.AddScoped<IPhoneOtpService, SomeOtpService>();
            services.AddScoped<IMailingService, SomeMailingService>();
        }

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<KoperasiTenteraContext>();

            var pendingMigrations = context.Database.GetPendingMigrations().ToList();
            if (pendingMigrations.Any())
            {
                context.Database.Migrate();
            }
        }
    }
}