﻿using Subscribo.Core.Abstractions.Enums;
using Subscribo.Core.Abstractions.Interfaces.Services;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Extensions;
using Subscribo.Data.DTOs;
using Subscribo.Data.Interfaces;

namespace Subscribo.Core.Services
{
    public class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoiceService
    {
        public async Task CreateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            InvoiceDto newInvoice = invoice.ToDto();
            await invoiceRepository.CreateInvoiceAsync(newInvoice, cancellationToken);
        }

        public async Task<Invoice?> GetByIdAsync(int invoiceId, CancellationToken cancellationToken)
        {
            InvoiceDto? invoice = await invoiceRepository.GetByIdAsync(invoiceId, cancellationToken);
            return invoice?.ToDomainObject();
        }

        public async Task UpdateInvoiceStatusAsync(int invoiceId, InvoiceStatus newStatus, CancellationToken cancellationToken)
        {
            await invoiceRepository.UpdateInvoiceStatusAsync(invoiceId, (int)newStatus, cancellationToken);
        }
    }
}
