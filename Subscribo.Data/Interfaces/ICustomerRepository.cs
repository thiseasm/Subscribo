using Subscribo.Data.DTOs;

namespace Subscribo.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(CustomerDTO customer, CancellationToken cancellationToken = default);
        Task<CustomerDTO?> GetByIdAsync(int customerId, CancellationToken cancellationToken = default);
    }
}
