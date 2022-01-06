using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models
{
    public partial class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } = new DateTime();
        public virtual bool Direction { get; set; } = true;
        public double Quantity { get; set; } = 0;

        [NotMapped]
        public Gateway Gateway { get; set; }
        public int TargetId { get; set; }
        [MaxLength(20)]
        public string Unit { get; set; }
    }
    public partial class Transaction
    {
        public virtual bool Post()
        {
            if (!Direction)
                Quantity = -Quantity;
            return this.Gateway.GetTargetObjectAndUpdate(TargetId, Quantity);

        }
        public void UnPost()
        {
            if (Direction)//true for income 
                Quantity = -Quantity;
            this.Gateway.GetTargetObjectAndUpdate(TargetId, Quantity);

        }

    }
}
