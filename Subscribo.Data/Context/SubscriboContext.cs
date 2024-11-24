using Microsoft.EntityFrameworkCore;
using Subscribo.Data.DTOs;

namespace Subscribo.Data.Context
{
    public class SubscriboContext : DbContext
    {
        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<InvoiceDTO> Invoices { get; set; }
        public DbSet<SubscriptionDTO> Subscriptions { get; set; }

        private string connectionString = string.Empty;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(connectionString);
    }
}
