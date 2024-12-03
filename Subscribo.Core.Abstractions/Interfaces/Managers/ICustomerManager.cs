using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Abstractions.Models.Requests;
using Subscribo.Core.Abstractions.Models.Responses;

namespace Subscribo.Core.Abstractions.Interfaces.Managers
{
    public interface ICustomerManager
    {
        Task<ApiResponse<Customer>> GetByIdAsync(int customerId, CancellationToken cancellationToken = default);
        Task<ApiResponse<int>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default);
    }
}
