using Subscribo.Core.Abstractions.Models;

namespace Subscribo.Core.Abstractions.Interfaces;

public interface ICustomerService
{
    Task CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
    Task<Customer?> GetCustomerByIdAsync(int customerId, CancellationToken cancellationToken = default);
    Task UpdateCustomerInfoAsync(Customer customer, CancellationToken cancellationToken = default);
}