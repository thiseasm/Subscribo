namespace Subscribo.Data.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; init; }
        public int SubscriptionId { get; init; }
        public DateTime IssueDate { get; init; }
        public decimal Amount { get; init; }
        public int StatusId { get; init; }


        public SubscriptionDto Subscription { get; init; }
    }
}
