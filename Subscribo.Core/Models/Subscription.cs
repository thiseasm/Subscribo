using Subscribo.Core.Enums;

namespace Subscribo.Core.Models
{
    public record Subscription
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public SubscriptionPlan Plan { get; init; }
        public decimal Price { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}
