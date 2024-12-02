using Subscribo.Core.Enums;

namespace Subscribo.Core.Models.Requests
{
    public class CreateSubscriptionRequest
    {
        public required int CustomerId { get; init; }
        public required SubscriptionPlan Plan { get; init; }
        public required decimal Price { get; init; }
        public DateTime StartDate { get; init; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
    }
}
