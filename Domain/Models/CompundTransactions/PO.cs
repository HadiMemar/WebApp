using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models.Gateways;
using WebApp.Domain.Models.Transactions;
using WebApp.Infrastructure.UnitOfWork;

namespace WebApp.Domain.Models.CompundTransactions
{
    public class PO : CompoundTransaction
    {
        public int HubId { get; set; }
        public PO()
        {

        }
        public PO(IUnitOfWork unitOfWork)
        {
            this.CustomerGateway = new HubCusOnPoGateway(HubId);
            this.ChildrenGateway = new HubOnPoGateway(HubId);
            this.unitOfWork = unitOfWork;
            this.ChildrenGateway._unitOfWork = unitOfWork;
            this.CustomerGateway._unitOfWork = unitOfWork;
        }
        public void CreateLeafTransactions(List<ItemEntry> entries)
        {
            Double total = 0;
            entries.ForEach(i =>
            {

                StockHubTrans aStockHubTrans = new StockHubTrans { HubId = HubId, Price = i.Price, TargetId = i.ItemId, Direction = Direction, Gateway = ChildrenGateway, Quantity = i.Qty };
                total += aStockHubTrans.GetAmount();
                aStockHubTrans = unitOfWork.StockHubTransactions.Add(aStockHubTrans);
                LeafTransactions.Add(aStockHubTrans);

            });
            Total = total;
            Transaction accountTrans = new AccountTrans { TargetId = TargetId, Direction = Direction, Gateway = CustomerGateway, Quantity = total };
            accountTrans = unitOfWork.Transactions.Add(accountTrans);
            LeafTransactions.Add(accountTrans);
        }
        public override bool Post()
        {
            if (LeafTransactions.Count != 0)
            {
                LeafTransactions.ForEach(leafTrans => leafTrans.Post());
                return true;
            }
            return false;
        }
    }
}
