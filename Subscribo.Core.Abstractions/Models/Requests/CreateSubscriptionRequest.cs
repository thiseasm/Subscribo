using Subscribo.Core.Abstractions.Enums;

namespace Subscribo.Core.Abstractions.Models.Requests
{
    public class CreateSubscriptionRequest
    {
        public required int CustomerId { get; init; }
        public required SubscriptionPlan Plan { get; init; }
        public required decimal Price { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; set; }
    }
}
