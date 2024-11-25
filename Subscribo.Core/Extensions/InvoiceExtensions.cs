
using Subscribo.Core.Enums;
using Subscribo.Core.Models;
using Subscribo.Data.DTOs;

namespace Subscribo.Core.Extensions
{
    public static class InvoiceExtensions
    {
        public static InvoiceDTO ToDTO(this Invoice invoice)
        => new()
        {
            Id = invoice.Id,
            Amount = invoice.Amount,
            StatusId = (int)invoice.Status,
            SubscriptionId = invoice.SubscriptionId,
            IssueDate = invoice.IssueDate
        };

        public static Invoice ToDomainObject(this InvoiceDTO invoiceDto)
        => new()
        {
            Id = invoiceDto.Id,
            Amount = invoiceDto.Amount,
            Status = (InvoiceStatus)invoiceDto.StatusId,
            SubscriptionId = invoiceDto.SubscriptionId,
            IssueDate = invoiceDto.IssueDate
        };
    }
}
