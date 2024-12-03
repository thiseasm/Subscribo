namespace Subscribo.Data.DTOs
{
    public class SubscriptionDto
    {
        public int SubscriptionId { get; set; }
        public int CustomerId { get; set; }
        public int PlanId { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusId { get; set; }


        public CustomerDto Customer { get; set; }
    }
}
