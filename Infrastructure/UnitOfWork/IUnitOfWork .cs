using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces.Repository;
using WebApp.Services.Repository;

namespace WebApp.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IItemRepository Items { get; }
        ICustomerRepository Customers { get; }
        IGatewayRepo Gateways { get; }
        ITargetRepo Targets { get; }
        IItemEntryRepo ItemEntries { get; }
        ITransactionRepository Transactions { get; }
        IPORepository POs { get; }
        ISORepository SOs { get; }


        int Complete();
    }
}
