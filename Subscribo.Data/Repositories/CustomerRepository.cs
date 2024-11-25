using Subscribo.Data.Context;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Data.Repositories
{ 
    public class CustomerRepository(SubscriboContext dbContext) : ICustomerRepository
    {
        public async Task CreateCustomerAsync(CustomerDTO customer, CancellationToken cancellationToken) => await dbContext.Customers.AddAsync(customer, cancellationToken);

        public async Task<CustomerDTO?> GetByIdAsync(int customerId, CancellationToken cancellationToken) => await dbContext.Customers.FindAsync([customerId], cancellationToken); 
        
    }
}
