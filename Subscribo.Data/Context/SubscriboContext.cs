using Microsoft.EntityFrameworkCore;
using Subscribo.Data.DTOs;

namespace Subscribo.Data.Context
{
    public class SubscriboContext(DbContextOptions<SubscriboContext> options) : DbContext(options)
    {
        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<InvoiceDTO> Invoices { get; set; }
        public DbSet<SubscriptionDTO> Subscriptions { get; set; }
    }
}
