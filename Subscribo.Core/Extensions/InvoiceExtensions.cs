using Subscribo.Core.Abstractions.Enums;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Data.DTOs;

namespace Subscribo.Core.Extensions
{
    public static class InvoiceExtensions
    {
        public static InvoiceDto ToDto(this Invoice invoice)
        => new()
        {
            InvoiceId = invoice.Id,
            Amount = invoice.Amount,
            StatusId = (int)invoice.Status,
            SubscriptionId = invoice.SubscriptionId,
            IssueDate = invoice.IssueDate
        };

        public static Invoice ToDomainObject(this InvoiceDto invoiceDto)
        => new()
        {
            Id = invoiceDto.InvoiceId,
            Amount = invoiceDto.Amount,
            Status = (InvoiceStatus)invoiceDto.StatusId,
            SubscriptionId = invoiceDto.SubscriptionId,
            IssueDate = invoiceDto.IssueDate
        };
    }
}
