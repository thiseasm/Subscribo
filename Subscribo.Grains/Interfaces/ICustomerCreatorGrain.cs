using Orleans;
using Subscribo.Core.Abstractions.Models;

namespace Subscribo.Grains.Interfaces
{
    public interface ICustomerCreatorGrain : IGrainWithIntegerKey
    {
        Task<int> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
