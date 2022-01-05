using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApp.Domain.Models
{
    public partial class Item : Target
    {
        [Key]
        public int Id { get; set; }
        public int HubId { get; set; }
        public Hub Hub { get; set; }
        public int OnHand { get; set; } = 0;
        public int OnPO { get; set; } = 0;


    }
    public partial class Item : Target
    {
        public override int GetTargetId()
        {
            return this.Id;
        }

        internal override bool Update(double quantity, string attribute)
        {
            if (this.GetType().GetProperty(attribute) != null)
            {

                int value = (int)this.GetType().GetProperty(attribute).GetValue(this);

                if (quantity > 0 || (int)value >= (int)Math.Abs(quantity))
                {
                    this.GetType().GetProperty(attribute).SetValue(this, value + (int)quantity);
                    Console.WriteLine("Item (" + Id + ") : " + this.GetType().GetProperty(attribute).Name + " updated " + value + " -> " + this.GetType().GetProperty(attribute).GetValue(this).ToString() + "\n");

                    return true;
                }

            }
            return false;
        }
    }
}
