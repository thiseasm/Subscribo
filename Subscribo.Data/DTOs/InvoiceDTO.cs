namespace Subscribo.Data.DTOs
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Amount { get; set; }
        public int StatusId { get; set; }


        public SubscriptionDto Subscription { get; set; }
    }
}
