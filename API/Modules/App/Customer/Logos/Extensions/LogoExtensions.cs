using API.Logos.Repositories;
using API.Modules.App.Customer.Logos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.Modules.App.Customer.Logo.Extensions
{
    public static class LogoExtensions
    {
        public static IServiceCollection AddLogoModule(this IServiceCollection services)
        {
            services.AddScoped<ILogoConfigRepository, LogoConfigRepository>();
            return services;
        }
    }
}