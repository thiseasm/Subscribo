using Subscribo.Core.Abstractions.Interfaces.Managers;
using Subscribo.Core.Abstractions.Interfaces.Services;
using Subscribo.Core.Managers;
using Subscribo.Core.Services;
using Subscribo.Data.Interfaces;
using Subscribo.Data.Repositories;

namespace Subscribo.Host.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRegistrations(this IServiceCollection services)
        {
            //Services
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();

            //Managers
            services.AddSingleton<ICustomerManager, CustomerManager>();

            //Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
        }
    }
}
