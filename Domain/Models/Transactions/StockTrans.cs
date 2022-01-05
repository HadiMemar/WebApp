using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models.Transactions
{
    public class StockTrans:Transaction
    {
        public int Price { get; set; }
        public double GetAmount()
        {
            return this.Quantity * Price;
        }
        public double GetQty()
        {
            return this.Quantity;
        }

    }
}
