using Subscribo.Core.Abstractions.Enums;
using Subscribo.Core.Abstractions.Models;

namespace Subscribo.Core.Abstractions.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice?> GetByIdAsync(int invoiceId, CancellationToken cancellationToken = default);
        Task CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken = default);
        Task UpdateInvoiceStatusAsync(int invoiceId, InvoiceStatus newStatus, CancellationToken cancellationToken = default);
    }
}
