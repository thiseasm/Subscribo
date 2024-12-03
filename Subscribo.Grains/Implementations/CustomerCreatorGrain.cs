using Orleans;
using Orleans.Concurrency;
using Subscribo.Core.Abstractions.Interfaces.Services;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Grains.Interfaces;

namespace Subscribo.Grains.Implementations
{
    [StatelessWorker(1)]
    public class CustomerCreatorGrain(ICustomerService customerService) : Grain, ICustomerCreatorGrain
    {
        public async Task<int> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
        =>  await customerService.CreateCustomerAsync(customer, cancellationToken);
    }
}
