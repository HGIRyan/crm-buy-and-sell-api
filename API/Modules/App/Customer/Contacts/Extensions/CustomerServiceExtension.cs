using API.Contacts.Interfaces;
using API.Contacts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.Modules.App.Customer.Contact.Extensions
{
    public static class CustomerServiceExtension
    {
        public static IServiceCollection AddCustomerModule(this IServiceCollection services)
        {
            services.AddScoped<IContact, ContactsService>();

            return services;
        }
    }
}