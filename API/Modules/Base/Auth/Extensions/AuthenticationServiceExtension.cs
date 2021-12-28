using API.Auth.Repository;
using API.Modules.Base.Auth.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.Modules.Base.Auth.Extensions
{
    public static class AuthenticationServiceExtension
    {
        public static IServiceCollection AddAuthenticationModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthManagerService, AuthManagerService>();
            services.AddScoped<IAuthentication, AuthenticationService>();
            services.AddScoped<IUserInfoRepository, UserInfoRepositoryRepository>();

            return services;
        }
    }
}