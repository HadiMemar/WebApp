using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Infrastructure.Repositories;
using WebApp.Interfaces.Repository;
using WebApp.Services.Repository;

namespace WebApp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Items = new ItemRepository(_context);
            Customers = new CustomerRepository(_context);
            Targets = new TargetRepo(_context);
            Gateways = new GatewayRepo(_context);
            ItemEntries = new ItemEntryRepo(_context);
            Transactions = new TransactionRepository(_context);
            POs = new PORepository(_context);
            SOs = new SORepository(_context);
        }
        public IItemRepository Items { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public ITargetRepo Targets { get; private set; }
        public IGatewayRepo Gateways { get; private set; }
        public IItemEntryRepo ItemEntries { get; private set; }
        public ITransactionRepository Transactions { get; private set; }
        public IPORepository POs { get; private set; }
        public ISORepository SOs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
