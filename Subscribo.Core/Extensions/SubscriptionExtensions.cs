using Subscribo.Core.Abstractions.Enums;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Data.DTOs;

namespace Subscribo.Core.Extensions
{
    public static class SubscriptionExtensions
    {
        public static SubscriptionDto ToDto(this Subscription subscription)
        => new()
        {
            SubscriptionId = subscription.Id,
            CustomerId = subscription.CustomerId,           
            StatusId = (int)subscription.Status,
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate,
            PlanId = (int)subscription.Plan,
            Price = subscription.Price
        };

        public static Subscription ToDomainObject(this SubscriptionDto subscriptionDto)
        => new()
        {
            Id = subscriptionDto.SubscriptionId,
            CustomerId = subscriptionDto.CustomerId,
            Status = (SubscriptionStatus)subscriptionDto.StatusId,
            StartDate = subscriptionDto.StartDate,
            EndDate = subscriptionDto.EndDate,
            Plan = (SubscriptionPlan)subscriptionDto.PlanId,
            Price = subscriptionDto.Price
        };
    }
}
