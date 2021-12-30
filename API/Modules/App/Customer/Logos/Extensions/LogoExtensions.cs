using API.Logos.Repositories;
using API.Modules.App.Customer.Logos.Interfaces;
using API.Modules.App.Customer.Logos.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.Modules.App.Customer.Logo.Extensions
{
    public static class LogoExtensions
    {
        public static IServiceCollection AddLogoModule(this IServiceCollection services)
        {
            services.AddScoped<ILogoConfigService, LogoConfigService>();
            services.AddScoped<ILogoConfigRepository, LogoConfigRepository>();
            return services;
        }
    }
}