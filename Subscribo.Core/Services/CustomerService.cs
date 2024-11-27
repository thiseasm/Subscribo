using Subscribo.Core.Extensions;
using Subscribo.Core.Interfaces;
using Subscribo.Core.Models;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Core.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        public async Task CreateCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            CustomerDto newCustomer = customer.ToDto();
            await customerRepository.CreateCustomerAsync(newCustomer, cancellationToken);
        }

        public async Task<Customer?> GetCustomerByIdAsync(int customerId, CancellationToken cancellationToken)
        {
            CustomerDto? customer = await customerRepository.GetByIdAsync(customerId, cancellationToken);
            return customer?.ToDomainObject();
        }
    }
}
