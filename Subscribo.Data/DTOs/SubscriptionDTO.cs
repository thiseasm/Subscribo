namespace Subscribo.Data.DTOs
{
    public class SubscriptionDto
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public int PlanId { get; init; }
        public decimal Price { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public int StatusId { get; init; }


        public CustomerDto Customer { get; init; }
    }
}
