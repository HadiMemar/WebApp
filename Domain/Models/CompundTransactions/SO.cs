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
    public class SO : CompoundTransaction
    {
        public int HubId { get; set; }
        public SO()
        {

        }
        public SO(IUnitOfWork unitOfWork)
        {
            this.CustomerGateway = new HubOnSOGateway(HubId);
            this.ChildrenGateway = new HubOnPoGateway(HubId);
            this.unitOfWork = unitOfWork;
            this.ChildrenGateway._unitOfWork = unitOfWork;
            this.CustomerGateway._unitOfWork = unitOfWork;
        }
        public override bool Post()
        {
            Double total = 0;
            Entries.ForEach(i =>
            {

                StockHubTrans t = new StockHubTrans { HubId = HubId, Price = i.Price, TargetId = i.ItemId, Direction = this.Direction, Gateway = ChildrenGateway, Quantity = i.Qty };
                if (t.Post())
                {
                    this.LeafTransactions.Add(t);
                    unitOfWork.Transactions.Add(t);
                    total += t.GetAmount();

                }

            });

            AccountTrans t = new AccountTrans { TargetId = TargetId, Direction = !Direction, Gateway = CustomerGateway, Quantity = total };
            if (t.Post())
            {
                this.LeafTransactions.Add(t);
                unitOfWork.Transactions.Add(t);
                Total = total;
                return true;
            }
            return false;

        }
    }
}
