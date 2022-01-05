using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models.Gateways;
using WebApp.Infrastructure.UnitOfWork;

namespace WebApp.Domain.Models.CompundTransactions
{
    public class SO : CompoundTransaction
    {
        [NotMapped]
        public override Gateway CustomerGateway { get; set; } = new HubOnSOGateway(1);
        [NotMapped]
        public override Gateway ChildrenGateway { get; set; } = new HubOnHandGateway(1);
        public SO()
        {

        }
        public SO(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
            this.ChildrenGateway._unitOfWork = unitOfWork;
            this.CustomerGateway._unitOfWork = unitOfWork;
        }
        public override bool Post()
        {
            Double total = 0;
            Entries.ForEach(i =>
            {

                Transaction t = new Transaction { TargetId = i.ItemId, Direction = this.Direction, Gateway = ChildrenGateway, Quantity = i.Qty };
                if (t.Post())
                {
                    total += i.Price * i.Qty;

                }

            });

            Transaction t = new Transaction { TargetId = TargetId, Direction = !Direction, Gateway = CustomerGateway, Quantity = total };
            if (t.Post())
            {
                Total = total;
                return true;
            }
            return false;

        }
    }
}
