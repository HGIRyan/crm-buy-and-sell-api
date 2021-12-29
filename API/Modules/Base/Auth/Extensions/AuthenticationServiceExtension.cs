using API.Auth.Repository;
using API.Modules.Base.Auth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace API.Modules.Base.Auth.Extensions
{
    public static class AuthenticationServiceExtension
    {
        public static IServiceCollection AddAuthenticationModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthManagerService, AuthManagerService>();
            services.AddScoped<IAuthentication, AuthenticationService>();
            services.AddScoped<IUserInfoRepository, UserInfoRepositoryRepository>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}