using Microsoft.EntityFrameworkCore;
using Subscribo.Data.DTOs;

namespace Subscribo.Data.Context
{
    public sealed class SubscriboContext(DbContextOptions<SubscriboContext> options) : DbContext(options)
    {
        public DbSet<CustomerDto> Customers { get; set; }
        public DbSet<InvoiceDto> Invoices { get; set; }
        public DbSet<SubscriptionDto> Subscriptions { get; set; }
    }
}
