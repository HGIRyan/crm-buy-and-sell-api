using API.SampleCustomers.Interfaces;
using API.Customers.SampleCustomers.Service;
using Microsoft.Extensions.DependencyInjection;

namespace API.Modules.App.Customer.Contact.Extensions
{
    public static class SampleCustomerServiceExtension
    {
        public static IServiceCollection AddSampleCustomerModule(this IServiceCollection services)
        {
            services.AddScoped<ISampleCustomers, SampleCustomerService>();

            return services;
        }
    }
}