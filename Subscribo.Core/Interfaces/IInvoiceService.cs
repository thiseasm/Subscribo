using Subscribo.Core.Enums;
using Subscribo.Core.Models;

namespace Subscribo.Core.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice?> GetByIdAsync(int invoiceId, CancellationToken cancellationToken);
        Task CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken);
        Task UpdateInvoiceStatusAsync(int invoiceId, InvoiceStatus newStatus, CancellationToken cancellationToken);
    }
}
