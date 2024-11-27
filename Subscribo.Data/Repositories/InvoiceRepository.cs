using Microsoft.EntityFrameworkCore;
using Subscribo.Data.Context;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Data.Repositories
{
    public class InvoiceRepository(SubscriboContext dbContext) : IInvoiceRepository
    {
        public async Task CreateInvoiceAsync(InvoiceDTO invoice, CancellationToken cancellationToken) 
            => await dbContext.Invoices.AddAsync(invoice, cancellationToken);

        public async Task<InvoiceDTO?> GetByIdAsync(int invoiceId, CancellationToken cancellationToken) 
            => await dbContext.Invoices
            .AsNoTracking()
            .Include(i => i.Subscription)
            .ThenInclude(s => s.Customer)
            .FirstOrDefaultAsync(i => i.Id == invoiceId);

        public async Task UpdateInvoiceStatusAsync(int invoiceId, int statusId, CancellationToken cancellationToken)
        {
            InvoiceDTO invoice = new() 
            {
                Id = invoiceId, 
                StatusId = statusId 
            };
            dbContext.Attach(invoice);
            dbContext.Entry(invoice).Property(i => i.StatusId).IsModified = true;
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
