using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Common.Base;
using WebApp.Domain.Models;
using WebApp.Domain.Models.CompundTransactions;
using WebApp.Domain.Models.Gateways;

namespace WebApp.Infrastructure
{
    public class AppDbContext : BaseDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CompoundTransaction> CompoundTransactions { get; set; }
        public DbSet<PO> POs{ get; set; }
        public DbSet<SO> Sos{ get; set; }
        public DbSet<Hub> Hubs { get; set; }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<HubGateway> HubGateways { get; set; }
        public DbSet<HubOnHandGateway> HubOnHandGateways { get; set; }
        public DbSet<HubOnPoGateway> HubOnPoGateways { get; set; }
        public DbSet<HubOnSOGateway> HubOnSOGateways { get; set; }


        public DbSet<ItemEntry> ItemEntrys { get; set; }
        public dynamic GetTable(string tableName)
        {

            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException($"'{nameof(tableName)}' cannot be null or whitespace.", nameof(tableName));
            }

            if (this.GetType().GetProperty(tableName) != null)
            {
                var table = this.GetType().GetProperty(tableName).GetValue(this);

                return table;
            }
            return null;
        }



    }
}
