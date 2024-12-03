using Subscribo.Core.Abstractions.Models;

namespace Subscribo.Core.Abstractions.Interfaces
{
    public interface ISubscriptionService
    {
        Task<Subscription?> GetByIdAsync(int subscriptionId, CancellationToken cancellationToken = default);
        Task CreateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken = default);
        Task ActivateSubscriptionAsync(int subscriptionId, CancellationToken cancellationToken = default);
        Task DeactivateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken = default);
    }
}
