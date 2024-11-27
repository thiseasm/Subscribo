using Subscribo.Core.Models;

namespace Subscribo.Core.Interfaces;

public interface ICustomerService
{
    Task CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
    Task<Customer?> GetCustomerByIdAsync(int customerId, CancellationToken cancellationToken = default);
}