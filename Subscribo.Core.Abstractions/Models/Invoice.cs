using Subscribo.Core.Abstractions.Enums;

namespace Subscribo.Core.Abstractions.Models
{
    public record Invoice
    {
        public required int Id { get; init; }
        public required int SubscriptionId { get; init; }
        public required DateTime IssueDate { get; init; }
        public required decimal Amount { get; init; }
        public required InvoiceStatus Status { get; init; }
    }

}
