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

        public async Task UpdateCustomerInfoAsync(CustomerDto customer, CancellationToken cancellationToken = default)
        {
            dbContext.Attach(customer);
            dbContext.Entry(customer).Property(i => i.Name).IsModified = true;
            dbContext.Entry(customer).Property(i => i.Email).IsModified = true;
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
