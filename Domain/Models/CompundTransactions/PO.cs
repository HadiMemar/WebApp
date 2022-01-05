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
        [NotMapped]
        public override Gateway CustomerGateway { get; set; } = new HubCusOnPoGateway(1);
        [NotMapped]
        public override Gateway ChildrenGateway  { get; set; } = new HubOnHandGateway(1);

        public PO()
        {

        }
        public PO(IUnitOfWork unitOfWork)
        {
            //this.CustomerGateway = new HubCusOnPoGateway(1);
            //this.ChildrenGateway = new HubOnHandGateway(1);
            this.unitOfWork = unitOfWork;
            this.ChildrenGateway._unitOfWork = unitOfWork;
            this.CustomerGateway._unitOfWork = unitOfWork;
        }
        public override bool Post()
        {
            Double total = 0;
            Entries.ForEach(i =>
            {

                StockHubTrans t = new StockHubTrans { HubId=1,Price=i.Price,TargetId = i.ItemId, Direction = Direction, Gateway = ChildrenGateway, Quantity = i.Qty };
                if (t.Post())
                {
                    total += t.GetAmount();
                }

            });

            Transaction t = new Transaction { TargetId = TargetId, Direction = Direction, Gateway = CustomerGateway, Quantity = total };
            if (t.Post())
            {
                Total = total;
                return true;
            }
            return false;

        }
    }
}
