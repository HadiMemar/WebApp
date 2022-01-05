using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Domain.Models
{
    public partial class Customer : Target
    {
        [Key]
        public int Id { get; set; }
        public double OnSO { get; set; } = 0;
        public double OnPO { get; set; } = 0;

        
    }
    public partial class Customer : Target
    {
        public override int GetTargetId()
        {
            return this.Id;
        }
        internal override bool Update(double quantity, string attribute)
        {
            if (string.IsNullOrWhiteSpace(attribute))
            {
                throw new ArgumentException($"'{nameof(attribute)}' cannot be null or whitespace.", nameof(attribute));
            }

            if (this.GetType().GetProperty(attribute) != null)
            {
                double value = (double)this.GetType().GetProperty(attribute).GetValue(this);
                if (quantity > 0 || (double)value >= Math.Abs(quantity))
                {
                    this.GetType().GetProperty(attribute).SetValue(this, value + quantity);

                    Console.WriteLine("Customer (" + Id + ") : " + this.GetType().GetProperty(attribute).Name + " updated " + value + " -> " + this.GetType().GetProperty(attribute).GetValue(this).ToString() + "\n");

                    return true;
                }
            }
            return false;
        }
    }
}
