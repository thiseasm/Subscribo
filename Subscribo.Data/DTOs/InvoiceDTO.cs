namespace Subscribo.Data.DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Amount { get; set; }
        public int StatusId { get; set; }


        public SubscriptionDTO Subscription { get; set; }
    }
}
