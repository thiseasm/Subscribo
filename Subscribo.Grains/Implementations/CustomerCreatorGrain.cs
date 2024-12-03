using Orleans;
using Orleans.Concurrency;
using Subscribo.Core.Abstractions.Interfaces.Services;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Abstractions.Models.Requests;
using Subscribo.Grains.Interfaces;

namespace Subscribo.Grains.Implementations
{
    [StatelessWorker(1)]
    public class CustomerCreatorGrain(ICustomerService customerService) : Grain, ICustomerCreatorGrain
    {
        public async Task<int> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            Customer customerToCreate = new()
            {
                Name = request.Name,
                Email = request.Email
            };
            return await customerService.CreateCustomerAsync(customerToCreate, cancellationToken);
        }
    }
}
