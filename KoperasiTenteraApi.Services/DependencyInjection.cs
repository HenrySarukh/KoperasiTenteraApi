using FluentValidation;
using KoperasiTenteraApi.Application.Common.Behaviours;
using KoperasiTenteraApi.Application.Contracts;
using KoperasiTenteraApi.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KoperasiTenteraApi.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOtpService, OtpService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValiadtionBehaviour<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly().GetName().Name);
            });

            services.AddMemoryCache();
        }
    }
}
