using Subscribo.Core.Models;

namespace Subscribo.Core.Interfaces
{
    public interface ISubscriptionService
    {
        Task<Subscription?> GetByIdAsync(int subscriptionId, CancellationToken cancellationToken = default);
        Task CreateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken = default);
        Task DeactivateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken = default);

    }
}
