using Subscribo.Data.DTOs;

namespace Subscribo.Data.Interfaces
{
    public interface IInvoiceRepository
    {
        Task CreateInvoiceAsync(InvoiceDto invoice, CancellationToken cancellationToken = default);
        Task UpdateInvoiceStatusAsync(int invoiceId, int statusId, CancellationToken cancellationToken = default);
        Task<InvoiceDto?> GetByIdAsync(int invoiceId, CancellationToken cancellationToken = default);
    }
}
