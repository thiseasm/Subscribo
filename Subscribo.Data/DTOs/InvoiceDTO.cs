namespace Subscribo.Data.DTOs
{
    public class InvoiceDTO
    {
        public required int Id { get; set; }
        public required int SubscriptionId { get; set; }
        public required DateTime IssueDate { get; set; }
        public required decimal Amount { get; set; }
        public required int StatusId { get; set; }
    }
}
