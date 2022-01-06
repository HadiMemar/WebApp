using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Models.Transactions;
using WebApp.Infrastructure.UnitOfWork;

namespace WebApp.Domain.Models
{
    public partial class CompoundTransaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public bool Direction { get; set; }
        public int TargetId { get; set; }
        public List<ItemEntry> Entries { get; set; }
        public List<Transaction> LeafTransactions { get; set; } = new List<Transaction>();
        [NotMapped]
        public virtual Gateway CustomerGateway { get; set; }
        [NotMapped]
        public virtual Gateway ChildrenGateway { get; set; }
        public Double Total { get; set; } = 0;

    }
    public partial class CompoundTransaction
    {
        [NotMapped]
        public IUnitOfWork unitOfWork { get; set; }
        public CompoundTransaction()
        {

        }
        public virtual bool Post()
        {
            Double total = 0;
            Entries.ForEach(i =>
            {

                Transaction t = new Transaction { TargetId = i.Id, Direction = this.Direction, Gateway = ChildrenGateway, Quantity = i.Qty };
                if (t.Post())
                {
                    total += i.Price * i.Qty;

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
        public double ReturnTotalPost()
        {
            return Total;
        }
    }
}
