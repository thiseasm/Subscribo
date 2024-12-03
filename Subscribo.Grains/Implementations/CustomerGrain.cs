using Orleans;
using Subscribo.Core.Abstractions.Enums;
using Subscribo.Core.Abstractions.Interfaces;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Abstractions.Models.Requests;
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
            var activeSubscription = _customer.Subscriptions.FirstOrDefault(x => x.Status == SubscriptionStatus.Active);
            if (activeSubscription == null)
            {
                throw new EntityNotFoundException($"Customer with ID {_customer.Id} has no active subscriptions to cancel.");
            }

            var subscriptionGrain = GrainFactory.GetGrain<ISubscriptionGrain>(activeSubscription.Id);
            await subscriptionGrain.EndSubscriptionAsync();
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
                Status = SubscriptionStatus.Inactive
            };

            await subscriptionService.CreateSubscriptionAsync(subscription, cancellationToken);

            var subscriptionGrain = GrainFactory.GetGrain<ISubscriptionGrain>(subscription.Id);
            await subscriptionGrain.BeginSubscriptionAsync();
        }

        public async Task UpdateCustomerInfoAsync(string name, string emailAddress)
        {
            await customerService.UpdateCustomerInfoAsync(_customer);

            _customer.Name = name;
            _customer.Email = emailAddress;
        }
    }
}
