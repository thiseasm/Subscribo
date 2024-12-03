using Orleans;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Abstractions.Models.Requests;

namespace Subscribo.Grains.Interfaces
{
    public interface ICustomerCreatorGrain : IGrainWithIntegerKey
    {
        Task<int> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default);
    }
}
