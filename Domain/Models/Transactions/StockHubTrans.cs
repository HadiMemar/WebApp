using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models.Transactions
{
    public class StockHubTrans:StockTrans
    {
        public int HubId { get; set; }
    }
}
