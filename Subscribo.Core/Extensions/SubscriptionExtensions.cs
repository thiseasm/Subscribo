using Subscribo.Core.Enums;
using Subscribo.Core.Models;
using Subscribo.Data.DTOs;

namespace Subscribo.Core.Extensions
{
    public static class SubscriptionExtensions
    {
        public static SubscriptionDTO ToDTO(this Subscription subscription)
        => new()
        {
            Id = subscription.Id,
            CustomerId = subscription.CustomerId,           
            StatusId = (int)subscription.Status,
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate,
            PlanId = (int)subscription.Plan,
            Price = subscription.Price
        };

        public static Subscription ToDomainObject(this SubscriptionDTO subscriptionDto)
        => new()
        {
            Id = subscriptionDto.Id,
            CustomerId = subscriptionDto.CustomerId,
            Status = (SubscriptionStatus)subscriptionDto.StatusId,
            StartDate = subscriptionDto.StartDate,
            EndDate = subscriptionDto.EndDate,
            Plan = (SubscriptionPlan)subscriptionDto.PlanId,
            Price = subscriptionDto.Price
        };
    }
}
