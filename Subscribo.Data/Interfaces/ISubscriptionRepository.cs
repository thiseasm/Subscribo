using Subscribo.Data.DTOs;

namespace Subscribo.Data.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<SubscriptionDto?> GetByIdAsync(int subscriptionId, CancellationToken cancellationToken = default);
        Task CreateSubscriptionAsync(SubscriptionDto subscription, CancellationToken cancellationToken = default);
        Task ActivateSubscriptionAsync(int subscriptionId, int statusId, CancellationToken cancellationToken = default);
        Task DeactivateSubscriptionAsync(SubscriptionDto subscription, CancellationToken cancellationToken = default);
    }
}
