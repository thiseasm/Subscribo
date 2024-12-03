using Subscribo.Core.Abstractions.Interfaces.Services;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Extensions;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Core.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        public async Task<int> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken)
        {
            CustomerDto newCustomer = new() 
            { 
                Email = customer.Email,
                Name = customer.Name
            };
            return await customerRepository.CreateCustomerAsync(newCustomer, cancellationToken);
        }

        public async Task<Customer?> GetCustomerByIdAsync(int customerId, CancellationToken cancellationToken)
        {
            CustomerDto? customer = await customerRepository.GetByIdAsync(customerId, cancellationToken);
            return customer?.ToDomainObject();
        }

        public Task UpdateCustomerInfoAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
