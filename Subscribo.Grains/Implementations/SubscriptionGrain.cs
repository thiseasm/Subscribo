using Orleans;
using Subscribo.Core.Interfaces;
using Subscribo.Core.Models;
using Subscribo.Grains.Exceptions;
using Subscribo.Grains.Interfaces;

namespace Subscribo.Grains.Implementations
{
    public class SubscriptionGrain(ISubscriptionService subscriptionService) : Grain, ISubscriptionGrain
    {
        private Subscription _subscription;
        public async Task OnActivateAsync()
        {
            var subscriptionId = Convert.ToInt32(this.GetPrimaryKeyLong());
            var subscription = await subscriptionService.GetByIdAsync(subscriptionId);

            if (subscription == null)
            {
                throw new EntityNotFoundException($"Subscription with ID {subscriptionId} does not exist.");
            }

            _subscription = subscription;
        }

        public async Task BeginSubscriptionAsync()
        {
            await subscriptionService.ActivateSubscriptionAsync(_subscription.Id);

            _subscription.Status = Core.Enums.SubscriptionStatus.Active;
        }

        public Task GenerateInvoiceAsync()
        {
            throw new NotImplementedException();
        }

        public async Task EndSubscriptionAsync()
        {
            var activeSubscription = new Subscription
            {
                Id = _subscription.Id,
                EndDate = DateTime.UtcNow,
                Status = Core.Enums.SubscriptionStatus.Inactive
            };

            await subscriptionService.DeactivateSubscriptionAsync(activeSubscription);

            _subscription.EndDate = DateTime.UtcNow;
            _subscription.Status = Core.Enums.SubscriptionStatus.Inactive;
        }
    }
}
