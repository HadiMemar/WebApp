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
    public partial class CompoundTransaction2
    {
        [Key]
        public int Id { get; set; }
        public bool Direction { get; set; }
        public int TargetId { get; set; }
        public List<Transaction> Transactions { get; set; }
        [NotMapped]
        public virtual Gateway CustomerGateway { get; set; }
        [NotMapped]
        public virtual Gateway ChildrenGateway { get; set; }
        public Double Total { get; set; } = 0;

    }
    public partial class CompoundTransaction2
    {
        [NotMapped]
        public IUnitOfWork unitOfWork { get; set; }
        public CompoundTransaction2()
        {

        }
        public CompoundTransaction2(Gateway customerGateway, Gateway childGateway)
        {
            this.CustomerGateway = customerGateway;
            this.ChildrenGateway = childGateway;
        }
        public bool Post()
        {
            Transactions.ForEach(t => t.Post());
            return true;

        }
        public double ReturnTotalPost()
        {
            return Total;
        }
    }
}
