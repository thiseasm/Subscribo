using Subscribo.Data.Context;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Data.Repositories
{ 
    public class CustomerRepository(SubscriboContext dbContext) : ICustomerRepository
    {
        public async Task CreateCustomerAsync(CustomerDto customer, CancellationToken cancellationToken)
        {
            await dbContext.Customers.AddAsync(customer, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<CustomerDto?> GetByIdAsync(int customerId, CancellationToken cancellationToken) => await dbContext.Customers.FindAsync([customerId], cancellationToken); 
        
    }
}
