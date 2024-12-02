using Orleans;
using Subscribo.Core.Interfaces;
using Subscribo.Core.Models;
using Subscribo.Core.Models.Requests;
using Subscribo.Grains.Exceptions;
using Subscribo.Grains.Interfaces;

namespace Subscribo.Grains.Implementations
{
    public class CustomerGrain(ICustomerService customerService, ISubscriptionService subscriptionService) : Grain, ICustomerGrain
    {
        private Customer _customer;

        public async Task OnActivateAsync()
        {
            var customerId = Convert.ToInt32(this.GetPrimaryKeyLong());
            var customer = await customerService.GetCustomerByIdAsync(customerId);

            if (customer == null)
            {
                throw new EntityNotFoundException($"Customer with ID {customerId} does not exist.");
            }

            _customer = customer;
        }

        public async Task CancelCurrentSubscriptionAsync()
        {
            var activeSubscription = _customer.Subscriptions.FirstOrDefault(x => x.Status == Core.Enums.SubscriptionStatus.Active);
            if (activeSubscription == null)
            {
                throw new EntityNotFoundException($"Customer with ID {_customer.Id} has no active subscriptions to cancel.");
            }

            activeSubscription.EndDate = DateTime.UtcNow;
            activeSubscription.Status = Core.Enums.SubscriptionStatus.Inactive;

            await subscriptionService.DeactivateSubscriptionAsync(activeSubscription);
        }

        public async Task CreateSubscriptionAsync(CreateSubscriptionRequest subscriptionRequest, CancellationToken cancellationToken)
        {
            var subscription = new Subscription
            {
                CustomerId = _customer.Id,
                Plan = subscriptionRequest.Plan,
                Price = subscriptionRequest.Price,
                StartDate = subscriptionRequest.StartDate,
                EndDate = subscriptionRequest.EndDate,
                Status = Core.Enums.SubscriptionStatus.Inactive
            };

            await subscriptionService.CreateSubscriptionAsync(subscription, cancellationToken);

            var subscriptionGrain = GrainFactory.GetGrain<ISubscriptionGrain>(subscription.Id);
        }

        public async Task UpdateCustomerInfoAsync(string name, string emailAddress)
        {
            await customerService.UpdateCustomerInfoAsync(_customer);

            _customer.Name = name;
            _customer.Email = emailAddress;
        }
    }
}
