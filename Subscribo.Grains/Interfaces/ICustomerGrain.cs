using Orleans;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Abstractions.Models.Requests;

namespace Subscribo.Grains.Interfaces;

public interface ICustomerGrain : IGrainWithIntegerKey
{
    Task UpdateCustomerInfoAsync(string name, string emailAddress, CancellationToken cancellationToken = default);
    Task CreateSubscriptionAsync(CreateSubscriptionRequest subscriptionRequest, CancellationToken cancellationToken = default);
    Task CancelCurrentSubscriptionAsync(CancellationToken cancellationToken = default);
    Task<Customer> GetById();
}