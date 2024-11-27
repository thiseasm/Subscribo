using Subscribo.Data.DTOs;

namespace Subscribo.Data.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task CreateSubscriptionAsync(SubscriptionDto subscription, CancellationToken cancellationToken = default);
        Task UpdateSubscriptionStatusAsync(int subscriptionId, int statusId, CancellationToken cancellationToken = default);
        Task<SubscriptionDto?> GetByIdAsync(int subscriptionId, CancellationToken cancellationToken = default);
    }
}
