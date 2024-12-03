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
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IInvoiceService, InvoiceService>();
            services.AddSingleton<ISubscriptionService, SubscriptionService>();

            //Managers
            services.AddSingleton<ICustomerManager, CustomerManager>();

            //Repositories
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
            services.AddSingleton<ISubscriptionRepository, SubscriptionRepository>();
        }
    }
}
