using Subscribo.Data.DTOs;

namespace Subscribo.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(CustomerDto customer, CancellationToken cancellationToken = default);
        Task<CustomerDto?> GetByIdAsync(int customerId, CancellationToken cancellationToken = default);
        Task UpdateCustomerInfoAsync(CustomerDto customer, CancellationToken cancellationToken = default);
    }
}
