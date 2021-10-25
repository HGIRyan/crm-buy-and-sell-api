using API.SampleCustomers.Interfaces;
using API.SampleCustomers.Services;
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