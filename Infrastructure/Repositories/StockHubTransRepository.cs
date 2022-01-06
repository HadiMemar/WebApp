using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models.Transactions;
using WebApp.Interfaces.Repository;

namespace WebApp.Infrastructure.Repositories
{
    public class StockHubTransRepository : GenericRepository<StockHubTrans>, IStockHubTransRepository
    {
        public StockHubTransRepository(AppDbContext context) : base(context)
        {

        }
    }
}
