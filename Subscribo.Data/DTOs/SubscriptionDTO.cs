namespace Subscribo.Data.DTOs
{
    public class SubscriptionDto
    {
        public required int Id { get; init; }
        public required int CustomerId { get; init; }
        public required int PlanId { get; init; }
        public required decimal Price { get; init; }
        public required DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public required int StatusId { get; init; }


        public CustomerDto Customer { get; init; }
    }
}
