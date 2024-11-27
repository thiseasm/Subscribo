using Subscribo.Data.DTOs;

namespace Subscribo.Data.Interfaces
{
    internal interface IInvoiceRepository
    {
        Task CreateInvoiceAsync(InvoiceDTO invoice, CancellationToken cancellationToken = default);
        Task UpdateInvoiceStatusAsync(int invoiceId, int statusId, CancellationToken cancellationToken = default);
        Task<InvoiceDTO?> GetByIdAsync(int invoiceId, CancellationToken cancellationToken = default);
    }
}
