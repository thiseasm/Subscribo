using Subscribo.Core.Abstractions.Enums;
using Subscribo.Core.Abstractions.Interfaces;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Extensions;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Core.Services
{
    public class SubscriptionService(ISubscriptionRepository subscriptionRepository) : ISubscriptionService
    {
        public async Task ActivateSubscriptionAsync(int subscriptionId, CancellationToken cancellationToken)
        {
            await subscriptionRepository.ActivateSubscriptionAsync(subscriptionId, (int)SubscriptionStatus.Active, cancellationToken); 
        }

        public async Task CreateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken)
        {
            SubscriptionDto newSubscription = subscription.ToDto();
            await subscriptionRepository.CreateSubscriptionAsync(newSubscription, cancellationToken);
        }

        public async Task DeactivateSubscriptionAsync(Subscription subscription, CancellationToken cancellationToken)
        {
            SubscriptionDto subscriptionToDeactive = subscription.ToDto();
            await subscriptionRepository.DeactivateSubscriptionAsync(subscriptionToDeactive, cancellationToken);
        }

        public async Task<Subscription?> GetByIdAsync(int subscriptionId, CancellationToken cancellationToken)
        {
            SubscriptionDto? subscription = await subscriptionRepository.GetByIdAsync(subscriptionId, cancellationToken);
            return subscription?.ToDomainObject();
        }
    }
}
